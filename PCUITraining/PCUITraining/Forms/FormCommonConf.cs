using PCUITCommon;
using System.Windows.Forms;
using static PCUITCommon.Views.BoolLabel;

namespace PCUITraining.Forms
{
    /// <summary>
    /// 共通設定ダイアログ.
    /// </summary>
    public partial class FormCommonConf : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FormCommonConf()
        {
            InitializeComponent();

            this.Init();
        }

        /// <summary>
        /// 設定値で初期化.
        /// </summary>
        public void Init()
        {
            var conf = PCUIT.Conf;

            this.bLblProxyUse.Init(BOOL_LABEL_TYPE.TYPE_DO_DONOT, conf.ProxyUse, (b) =>
            {
                this.tBoxID.Enabled = b;
                this.tBoxPassword.Enabled = b;
            });
            this.tBoxID.Text = conf.ProxyId;
            this.tBoxPassword.Text = conf.ProxyPassword;
        }

        /// <summary>
        /// 保存処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            var conf = PCUIT.Conf;

            conf.ProxyUse = this.bLblProxyUse.Value;
            conf.ProxyId = this.tBoxID.Text.Trim();
            conf.ProxyPassword = this.tBoxPassword.Text.Trim();

            var result = conf.Save();
            if (result.IsNG)
            {
                MessageBox.Show($"共通データの保存に失敗しました\n{result.Message}");
                return;
            }

            this.Close();
        }
    }
}
