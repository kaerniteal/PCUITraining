using Common.Extentions;
using System;
using System.Windows.Forms;

namespace Common.Progress
{
    /// <summary>
    /// プログレスバーフォーム.
    /// </summary>
    public partial class FromProgressBar : Form, IProgressObserver
    {
        /// <summary>
        /// 対象処理.
        /// </summary>
        private Action<ProgressCtl> Action { get; set; }

        /// <summary>
        /// 進捗管理クラス.
        /// </summary>
        private ProgressAction ProgressRoot { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FromProgressBar(Action<ProgressCtl> action)
        {
            InitializeComponent();

            this.Action = action;

            this.ProgressRoot = new ProgressAction(this);

            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FromProgressBar_Load(object sender, EventArgs e)
        {
            // 非同期処理呼び出し.
            await this.ProgressRoot.Start(this.Action);

            // 非同期処理終了後処理.
            this.Close();
        }

        /// <summary>
        /// IProgressObserverの実装.
        /// </summary>
        public void ProgressNotify(int progress)
        {
            this.UIInvoke(() =>
            {
                this.progressBar.Value = progress;
            });
        }
    }
}
