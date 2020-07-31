using Common.Extentions;
using Common.Lang.Japanese;
using System;
using System.Drawing;
using System.Windows.Forms;
using TextInputExercise.Executors;
using TextInputExercise.Interfaces;
using TypingExercise;

namespace TextInputExercise.Views
{
    public partial class FormTIExc : Form, ITIExcViewer
    {
        /// <summary>
        /// ゲームインスタンス.
        /// </summary>
        private ITIExcGameInstance GameInstance { get; set; }

        /// <summary>
        /// 実行インタフェース.
        /// </summary>
        private ITIExcExecutor Executor { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="gameInstance">ゲームインスタンス</param>
        public FormTIExc(ITIExcGameInstance gameInstance)
        {
            InitializeComponent();

            this.GameInstance = gameInstance;
            this.Executor = null;

            var conf = this.GameInstance.GetTextConf();

            this.StartNewGame();
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTIExc_Load(object sender, System.EventArgs e)
        {
            this.rtBoxText.Focus();
        }

        /// <summary>
        /// テキスト選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBpxText_MouseUp(object sender, MouseEventArgs e)
        {
            // 読み解析.
            var kanji = this.tBpxText.SelectedText.Trim();
            var words = MorphologicalAnalysis.PhoneticAnalyze(kanji);
            this.lblYomi.Text = string.Join(" ", words);
            this.rtBoxText.Focus();
        }

        /// <summary>
        /// Key入力を取得.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtBoxText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Esc
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Executor.Stop();
                this.Close();
            }
        }

        /// <summary>
        /// テキスト入力変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtBoxText_TextChanged(object sender, System.EventArgs e)
        {
            this.Executor.InputText(this.rtBoxText.Text);
        }

        /// <summary>
        /// ゲーム開始.
        /// </summary>
        private void StartNewGame()
        {
            var num = TIExc.Conf.NnumberOfQuestions;
            var newList = this.GameInstance.CreateNewTextList(num);

            this.Executor = new SetExecutor(newList, this);
            this.Executor.Start();
        }

        /// <summary>
        /// 新しい入力対象文字列をセットする.
        /// </summary>
        /// <param name="text">入力対象文字列</param>
        public void SetNewText(string text)
        {
            this.tBpxText.Text = text;
            this.lblYomi.Text = string.Empty;
            this.rtBoxText.Text = string.Empty;

            // TODO:実装
            //// イメージストアを新しくする.
            //var imageStore = this.pPanel.CreateNewImageStore();

            //// Webが有効な場合、画像を取得して表示する.
            //if (PCUIT.Conf.EnableWeb)
            //{
            //    // パラメータを生成.
            //    var param = new Tuple<string, PicturePanel, ImageStore>(
            //        this.GameInstance.CreateWebKeyWord(word),
            //        this.pPanel,
            //        imageStore);

            //    // 読み込み処理を別スレッドで実行.
            //    var thread = new Thread(new ParameterizedThreadStart(GetImageFromGoogle));
            //    thread.Start(param);
            //}
        }

        /// <summary>
        /// 入力文字列に対する結果を通知.
        /// </summary>
        /// <param name="correct">正しく入力できている分</param>
        /// <param name="missTypes">ミスタイプ文字</param>
        public void ShowInputResult(string correct, string missTypes)
        {
            // 現在の選択状態を覚えておく
            int sBegin = this.rtBoxText.SelectionStart;
            int sLen = this.rtBoxText.SelectionLength;

            //カレットを先頭に移動
            this.rtBoxText.Select(0, 0);

            // 正しい部分を選択.
            this.rtBoxText.SelectionLength = correct.Length;

            // 色をAquaにする
            this.rtBoxText.SelectionColor = Color.Aqua;

            // カレットを移動.
            this.rtBoxText.Select(correct.Length, 0);

            // 正しい部分を選択.
            this.rtBoxText.SelectionLength = this.rtBoxText.Text.Length;

            // 色をWhiteにする
            this.rtBoxText.SelectionColor = Color.White;

            //選択状態を元に戻す
            this.rtBoxText.Select(sBegin, sLen);
        }

        /// <summary>
        /// 単語入力毎の結果を通知.
        /// </summary>
        public void ShowTextResult(TextResult result)
        {
            this.GameInstance.ShowTextResult(result);
        }

        /// <summary>
        /// 実行後の総合結果を通知.
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
    }
}
