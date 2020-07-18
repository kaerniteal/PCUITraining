using Common.Extentions;
using Common.Web;
using PCUITCommon;
using PCUITCommon.Datas;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using TypingExercise.Definitions;
using TypingExercise.Executors;
using TypingExercise.Interfaces;

namespace TypingExercise.Views
{
    /// <summary>
    /// 実行ダイアログ.
    /// </summary>
    public partial class FormTypExc : Form, ITypExcViewer
    {
        /// <summary>
        /// ゲームインスタンス.
        /// </summary>
        private ITypExcGameInstance GameInstance { get; set; }

        /// <summary>
        /// 実行インタフェース.
        /// </summary>
        private ITypExcExecutor Executor { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="gameInstance">ゲームインスタンス</param>
        public FormTypExc(ITypExcGameInstance gameInstance)
        {
            InitializeComponent();

            this.GameInstance = gameInstance;
            this.Executor = null;

            var conf = this.GameInstance.GetWordConf();

            if (conf.ShowCorrectSpelling)
            {
                var spellingFont = PCUIT.GetFont(60);
                if (conf.ShowAllSpell)
                {
                    spellingFont = PCUIT.GetFont(36);
                }
                this.lblSpelling1.Font = spellingFont;
                this.lblSpelling2.Font = spellingFont;
                this.lblSpelling3.Font = spellingFont;
                this.lblSpelling4.Font = spellingFont;
            }
            else
            {
                this.lblSpelling1.Visible = false;
                this.lblSpelling2.Visible = false;
                this.lblSpelling3.Visible = false;
                this.lblSpelling4.Visible = false;
            }

            if (conf.ShowKeyboard)
            {
                this.keyboardPanel1.SetKeyMap(conf.ShowSpellUpper);
            }
            else
            {
                this.keyboardPanel1.Visible = false;
            }

            if (conf.ShowFinger)
            {
                this.fingerPanel.SetKeyMap();
            }
            else
            {
                this.fingerPanel.Visible = false;
            }

            this.StartNewGame();
        }

        /// <summary>
        /// Key入力を取得.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormExec_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Esc
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Executor.Stop();
                this.Close();
            }

            // 実行クラスへ通知.
            this.Executor.InputKey(e.KeyChar);
        }

        /// <summary>
        /// ゲーム開始.
        /// </summary>
        private void StartNewGame()
        {
            var num = TypExc.Conf.NnumberOfQuestions;
            var newList = this.GameInstance.CreateNewWordList(num);

            this.Executor = new SetExecutor(newList, this);
            this.Executor.Start();
        }

        /// <summary>
        /// 新しい入力対象単語をセットする.
        /// </summary>
        /// <param name="word">入力対象文字列</param>
        /// <returns>関連するイメージを抱えるストア</returns>
        public ImageStore SetNewWord(string word)
        {
            this.lblWord.Text = word;

            // イメージストアを新しくする.
            var imageStore = this.pPanel.CreateNewImageStore();

            // Webが有効な場合、画像を取得して表示する.
            if (PCUIT.Conf.EnableWeb)
            {
                // パラメータを生成.
                var param = new Tuple<string, PicturePanel, ImageStore>(
                    this.GameInstance.CreateWebKeyWord(word),
                    this.pPanel,
                    imageStore);

                // 読み込み処理を別スレッドで実行.
                var thread = new Thread(new ParameterizedThreadStart(GetImageFromGoogle));
                thread.Start(param);
            }

            // 結果に含めるため、イメージストアを返す.
            return imageStore;
        }

        /// <summary>
        /// Key入力に対する結果を通知.
        /// </summary>
        /// <param name="inputed">入力済み文字列</param>
        /// <param name="current">入力中文字列</param>
        /// <param name="spellings">次の入力文字の綴りリスト</param>
        /// <param name="missTypes">ミスタイプ文字</param>
        public void ShowKeyResult(string inputed, string current, List<CorrectSpelling> spellings, string missTypes)
        {
            this.lblInputed.Text = inputed + current;

            // 綴りラベルリスト.
            var lblList = new List<Label>
            {
                this.lblSpelling1,
                this.lblSpelling2,
                this.lblSpelling3,
                this.lblSpelling4,
            };

            var conf = this.GameInstance.GetWordConf();

            if (conf.ShowCorrectSpelling)
            {
                if (conf.ShowAllSpell)
                {
                    // 全ての綴りを表示する場合.
                    // 綴り表示エリアに一つずつセットする.
                    // 前回表示情報をクリアするため、外側のループはラベルでなきゃだめ.
                    for (var ii = 0; ii < lblList.Count; ii++)
                    {
                        var spellSet = string.Empty;
                        if (ii < spellings.Count)
                        {
                            var correct = spellings[ii];
                            if (0 < correct.Spells.Count)
                            {
                                var spels = string.Join("\n", correct.Spells.ToArray());
                                if (conf.ShowSpellUpper)
                                {
                                    spels = spels.ToUpper();
                                }

                                spellSet = correct.Cha + "\n" + spels;
                            }
                        }

                        lblList[ii].Text = spellSet;
                    }
                }
                else
                {
                    // 最も優先度の高い綴りのみ表示する場合.
                    var cha = string.Empty;
                    var spell = string.Empty;

                    if (0 < spellings.Count)
                    {
                        var correct = spellings[0];
                        cha = correct.Cha;
                        if (0 < correct.Spells.Count)
                        {
                            spell = correct.Spells[0];
                        }
                    }

                    this.lblSpelling1.Text = cha;
                    this.lblSpelling2.Text = spell;
                }
            }

            // KeyBoardを点燈させる.
            if (conf.ShowKeyboard)
            {
                // キーボードナビゲーション用の文字を取得する.
                // 最も優先度の高いSpellでナビゲーションする
                // spellingsには入力中の文字列に続くスペルしか入っていない為、
                // 先頭を無条件で使用する.
                var nextKey = string.Empty;
                if (0 < spellings.Count)
                {
                    var correct = spellings[0];
                    if (0 < correct.Spells.Count)
                    {
                        var spell = correct.Spells[0];
                        if (current.Length < spell.Length)
                        {
                            // Spellの入力中部分を除いた残り部分を切り出す.
                            nextKey = spell.Substring(current.Length);
                        }
                    }
                }

                this.keyboardPanel1.SetLightKey(nextKey);

                if (conf.ShowFinger)
                {
                    this.fingerPanel.SetLightFinger(nextKey);
                }
            }

            // MissTypeを表示.
            if (missTypes.IsEmpty())
            {
                this.lblMissTypes.Visible = false;
            }
            else
            {
                this.lblMissTypes.Visible = true;
                this.lblMissTypes.Text = "ミス！\n\n [{0}]".Fmt(missTypes);
            }
        }

        /// <summary>
        /// 単語入力毎の結果を通知する.
        /// </summary>
        public void ShowWordResult(WordResult result)
        {
            this.GameInstance.ShowWordResult(result);
        }

        /// <summary>
        /// 実行終了を通知する.
        /// </summary>
        /// <param name="result">実行結果</param>
        public void ShowSetResult(SetResult result)
        {
            var dlgResult = this.GameInstance.ShowSetResultDlg(result);

            // もう一回の場合.
            if (DialogResult.OK == dlgResult)
            {
                this.StartNewGame();
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// 画像取得処理.
        /// </summary>
        /// <param name="paramater"></param>
        private static void GetImageFromGoogle(object paramater)
        {
            // パラメータを取得.
            var param = paramater as Tuple<string, PicturePanel, ImageStore>;
            if (null == param)
            {
                return;
            }

            // WebClientを生成.
            var wc = PCUIT.GetWebClient();

            // 画像URLをGoogleから取得.
            var google = new GetImageUrlFromGoogle(wc);
            var urls = google.GetImageUrls(param.Item1, param.Item2.GetMaxImageCount());

            // 画像URLから画像データを取得.
            var downloader = new Downloader(wc);
            for (var ii = 0; ii < urls.Count; ii++)
            {
                // 一枚ダウンロードして.
                var image = downloader.GetImage(urls[ii]);

                // イメージコンポーネントにセットする
                // 非同期更新なため、このイメージコンポーネントが最新のコンポーネントとは限らないが、セットする
                param.Item3.SetImage(ii, image);

                // パネルに反映.
                // 上でセットしたコンポーネントをまだ抱えているかどうかはわからないが、パネルを更新する.
                param.Item2.UpdateImage();
            }
        }
    }
}
