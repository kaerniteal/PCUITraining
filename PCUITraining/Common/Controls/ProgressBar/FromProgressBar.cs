using Common.Extentions;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.Controls.ProgressBar.FromProgressBar;

namespace Common.Controls.ProgressBar
{
    /// <summary>
    /// プログレスバーフォーム.
    /// </summary>
    public partial class FromProgressBar : Form, IProgressCtl
    {
        /// <summary>
        /// 最大値.
        /// </summary>
        private int Max { get; set; }

        /// <summary>
        /// 対象処理.
        /// </summary>
        private Action<IProgressCtl> Action { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FromProgressBar(Action<IProgressCtl> action)
        {
            InitializeComponent();

            this.Action = action;

            this.SetMax(100);
            this.progressBar.Value = 0;
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FromProgressBar_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                this.Action(this);
            });

            this.SetProgress(this.Max);
            this.Close();
        }

        /// <summary>
        /// 最大をセットする.
        /// </summary>
        /// <param name="max">最大</param>
        public void SetMax(int max)
        {
            this.UIInvoke(() =>
            {
                this.Max = max;
                this.progressBar.Maximum = max;
            });
        }

        /// <summary>
        /// 進捗をセットする.
        /// </summary>
        /// <param name="val">進捗</param>
        public void SetProgress(int val)
        {
            this.UIInvoke(() =>
            {
                this.progressBar.Value = val;
            });
        }

        /// <summary>
        /// 進捗管理I/F
        /// </summary>
        public interface IProgressCtl
        {
            /// <summary>
            /// 最大をセットする.
            /// </summary>
            /// <param name="max">最大</param>
            void SetMax(int max);

            /// <summary>
            /// 進捗をセットする.
            /// </summary>
            /// <param name="val">進捗</param>
            void SetProgress(int val);
        }
    }
}
