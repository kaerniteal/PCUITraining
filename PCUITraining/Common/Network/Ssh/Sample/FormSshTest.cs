using Common.Extentions;
using System;
using System.Windows.Forms;

namespace Common.Network.Ssh.Sample
{
    public partial class FormSshTest : Form, ISshOutputWriter
    {
        /// <summary>
        /// SSH接続クラス.
        /// </summary>
        private SshConnection Ssh { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FormSshTest()
        {
            InitializeComponent();

            this.Ssh = new SshConnection();
            this.Ssh.AddWriter(this);
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>s
        /// <param name="e"></param>
        private void FormSshTest_Load(object sender, EventArgs e)
        {
            this.tBoxHostName.Text = "133.216.67.17";
            this.tBoxHostUserID.Text = "k.nakamura_pascal";
            this.tBoxHostPassword.Text = string.Empty;

            this.grpHost.Focus();
            this.tBoxHostPassword.Focus();
        }

        /// <summary>
        /// 接続ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            var hostname = this.tBoxHostName.Text.Trim();
            var userId = this.tBoxHostUserID.Text.Trim();
            var password = this.tBoxHostPassword.Text.Trim();

            if (hostname.IsEmpty())
            {
                MessageBox.Show("ホスト名を入力してください");
                return;
            }
            if (userId.IsEmpty())
            {
                MessageBox.Show("ユーザーIDを入力してください");
                return;
            }
            if (password.IsEmpty())
            {
                MessageBox.Show("パスワードを入力してください");
                return;
            }

            this.Ssh.Connect(hostname, userId, password);
        }

        /// <summary>
        /// 切断ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            this.Ssh.DisConnect();
        }

        /// <summary>
        /// コマンド送信ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSshExt_Click(object sender, EventArgs e)
        {
            var command = this.tBoxCommand.Text.Trim();
            this.Ssh.Cmd(command);

            this.tBoxCommand.Text = string.Empty;
        }

        /// <summary>
        /// パスワード送信ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPass_Click(object sender, EventArgs e)
        {
            var password = this.tBoxPassword.Text.Trim();
            this.Ssh.Cmd(password);

            this.tBoxPassword.Text = string.Empty;
        }

        /// <summary>
        /// 終了ボタン.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Ssh.DisConnect();
            Application.Exit();
        }

        /// <summary>
        /// ISshOutputWriterの実装.
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            if (message.IsEmpty())
            {
                return;
            }

            this.tBox.Focus();
            this.tBox.AppendText(message);

            this.tBoxCommand.Focus();
        }
    }
}
