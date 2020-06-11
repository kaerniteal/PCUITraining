using Common.Controls;
using Common.Extentions;
using Common.Web;
using PCUITCommon;
using PCUITCommon.Datas;
using PCUITCommon.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using TypingExercise.Definitions;
using TypingExercise.Executors;
using TypingExercise.Interfaces;
using TypingExercise.WordSet;

namespace TypingExercise.Views
{
    /// <summary>
    /// 実行フォーム.
    /// </summary>
    public partial class FormTypExc : Form, IViewer
    {
        /// <summary>
        /// ワードセット.
        /// </summary>
        private WordSetBase WordSet { get; set; }

        /// <summary>
        /// ユーザーデータ.
        /// </summary>
        private UserData UserData { get; set; }

        /// <summary>
        /// 実行インタフェース.
        /// </summary>
        private IExecutor Executor { get; set; }

        /// <summary>
        /// ミスタイプ表示ToolTip
        /// </summary>
        private CustomToolTip MissBallon { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="wordSet">ワードセット</param>
        /// <param name="userData">ユーザーデータ</param>
        public FormTypExc(WordSetBase wordSet, UserData userData)
        {
            InitializeComponent();

            this.WordSet = wordSet;
            this.UserData = userData;

            this.MissBallon = new CustomToolTip
            {
                CustomFont = PCUIT.GetFont(48),
                FontColor = Color.Red,
                BackgroundColor = Color.DimGray,
            };

            if (TypExc.Conf.ShowKeyboard)
            {
                this.keyboardPanel1.SetKeyMap(TypExc.Conf.ShowSpellUpper);
            }
            else
            {
                this.keyboardPanel1.Visible = false;
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
            var newList = this.WordSet.CreateNewGameList(num);
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
                    this.WordSet.CreateWebKeyWord(word),
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
                        if (TypExc.Conf.ShowSpellUpper)
                        {
                            spels = spels.ToUpper();
                        }

                        spellSet = correct.Cha + "\n" + spels;
                    }
                }

                lblList[ii].Text = spellSet;
            }

            // KeyBoardを点燈させる.
            if (TypExc.Conf.ShowKeyboard)
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
            }

            // MissTypeを表示.
            if (missTypes.IsEmpty())
            {
                this.MissBallon.Active = false;
            }
            else
            {
                this.MissBallon.Active = true;
                this.MissBallon.Show("まちがい！\n [" + missTypes + "]", this.lblSpelling4, 500);
            }
        }

        /// <summary>
        /// 単語入力毎の結果を通知する.
        /// </summary>
        public void ShowWordResult(WordResult result)
        {
            if (TypExc.Conf.ShowWordResult)
            {
                // 単語の結果表示ダイアログを取得して表示.
                var wordResultDlg = this.WordSet.GetWordResultDlg();
                wordResultDlg.ShowWordResultDlg(result);
            }
        }

        /// <summary>
        /// 実行終了を通知する.
        /// </summary>
        /// <param name="result">実行結果</param>
        public void ShowSetResult(SetResult result)
        {
            // 結果表示ダイアログを取得して表示.
            var setResultDlg = this.WordSet.GetSetResultDlg();
            //*********************************************************//
            // 結果ダイアログの中で結果をユーザーデータに保存している  //
            //*********************************************************//
            var dlgResult = setResultDlg.ShowSetResultDlg(result, this.UserData);

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
            var wc = PCUIT.Conf.ProxyUse
                ? new WebClientWithSystemProxy(PCUIT.Conf.ProxyId, PCUIT.Conf.ProxyPassword)
                : new WebClient();

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
