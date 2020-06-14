using System;
using System.Windows.Forms;

namespace PCUITCommon.Views
{
    /// <summary>
    /// メッセージボックスダイアログ.
    /// </summary>
    public partial class FormMessageBox : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        private FormMessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OKボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// はいボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// いいえボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        /// <summary>
        /// メッセージボックス表示.
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <returns></returns>
        public static DialogResult Show(string message)
        {
            var dlg = new FormMessageBox();
            dlg.lblMessage.Text = message;
            dlg.btnYes.Visible = false;
            dlg.btnNo.Visible = false;
            return dlg.ShowDialog();
        }

        /// <summary>
        /// メッセージボックス表示.
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <returns></returns>
        public static DialogResult YesNo(string message)
        {
            var dlg = new FormMessageBox();
            dlg.lblMessage.Text = message;
            dlg.btnOK.Visible = false;
            return dlg.ShowDialog();
        }
    }
}
