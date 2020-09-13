using Common.Extentions;
using Common.Progress;
using System;
using System.Windows.Forms;
using static Common.WinForms.Ccontrols.ProgressBarWithMessage;

namespace Common.WinForms.Forms
{
    /// <summary>
    /// プログレスバーフォーム.
    /// </summary>
    public partial class FormProgressBar : Form, IProgressObserver
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
        /// <param name="action">非同期処理.</param>
        /// <param name="mode">メッセージ表示モード.</param>
        public FormProgressBar(Action<ProgressCtl> action, MESSAGE_MODE mode = MESSAGE_MODE.NON)
        {
            InitializeComponent();

            this.Action = action;
            this.progressBar.MessageMode = mode;

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
        public void ProgressNotify(int progress, string message)
        {
            this.UIInvoke(() =>
            {
                this.progressBar.Value = progress;
                this.progressBar.SetMessage(message);
            });
        }
    }
}
