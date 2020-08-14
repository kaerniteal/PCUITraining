using Common.Extentions;
using MouseExercise.MusExcSet.InsectCollectingSet;
using PCUITCommon;
using PCUITCommon.Views;
using System.Windows.Forms;
using TextInputExercise.TextSet.AnimeTitleSet;
using TypingExercise.WordSet.PokemonSet;
using static PCUITCommon.Views.UserIcon;

namespace PCUITraining.Forms
{
    /// <summary>
    /// 設定ダイアログ.
    /// </summary>
    public partial class FormSetting : Form
    {
        /// <summary>
        /// ユーザーアイコングループ.
        /// </summary>
        private UserIconGrp UserIconGrp { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FormSetting()
        {
            InitializeComponent();

            this.lblVersion.Text = $"{PCUITraining.APP_NAME} Ver{PCUITraining.APP_VER}";

            // ユーザーアイコンをセット.
            this.ReloadUsers();
        }

        /// <summary>
        /// ユーザーのリロード.
        /// </summary>
        private void ReloadUsers()
        {
            // ユーザーデータリロード.
            PCUIT.UserDataManager.LoadUserDataAll();

            // ユーザーアイコンをセット.
            this.UserIconGrp = this.userSelector.SetUserIcons((ud) =>
            {
                this.UpdateEnable();
            });

            this.UpdateEnable();
        }

        /// <summary>
        /// ボタンの有効/無効を制御する.
        /// </summary>
        private void UpdateEnable()
        {
            var isSelected = null != this.UserIconGrp.GetSelectedUserData();

            this.btnConf1.Enabled = isSelected;
            this.btnConf2.Enabled = isSelected;
            this.btnConf3.Enabled = isSelected;

            this.btnUserUpdate.Enabled = isSelected;
            this.btnUserDelete.Enabled = isSelected;
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSetting_Load(object sender, System.EventArgs e)
        {
            this.UpdateEnable();
        }

        /// <summary>
        /// 設定ボタン１
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConf1_Click(object sender, System.EventArgs e)
        {
            var userData = this.UserIconGrp.GetSelectedUserData();
            if (null == userData)
            {
                return;
            }

            var conf = new FormPokemonSetConf(userData);
            conf.ShowDialog();
        }

        /// <summary>
        /// 設定ボタン２
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConf2_Click(object sender, System.EventArgs e)
        {
            var userData = this.UserIconGrp.GetSelectedUserData();
            if (null == userData)
            {
                return;
            }

            var conf = new FormInsectCollectingSetConf(userData);
            conf.ShowDialog();
        }

        /// <summary>
        /// 設定ボタン３
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConf3_Click(object sender, System.EventArgs e)
        {
            var userData = this.UserIconGrp.GetSelectedUserData();
            if (null == userData)
            {
                return;
            }

            var conf = new FormAnimeTitleSetConf(userData);
            conf.ShowDialog();
        }

        /// <summary>
        /// ユーザー追加.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserAdd_Click(object sender, System.EventArgs e)
        {
            if (!this.UserIconGrp.CanAdd())
            {
                FormMessageBox.Show("これ以上ユーザーを追加できません");
                return;
            }

            var dlg = new FormSettingUser(this.UserIconGrp);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                FormMessageBox.Show("ユーザーを追加しました。");

                // 再ロード.
                this.ReloadUsers();
            }
        }

        /// <summary>
        /// ユーザー編集.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserUpdate_Click(object sender, System.EventArgs e)
        {
            var userData = this.UserIconGrp.GetSelectedUserData();
            if (null == userData)
            {
                FormMessageBox.Show("ユーザーが選択されていません");
                return;
            }

            // 複製を渡す.
            var dlg = new FormSettingUser(this.UserIconGrp, userData.Clone());
            if (DialogResult.OK == dlg.ShowDialog())
            {
                FormMessageBox.Show("{0}を更新しました。".Fmt(userData.Name));

                // 再ロード.
                this.ReloadUsers();
            }
        }

        /// <summary>
        /// ユーザー削除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserDelete_Click(object sender, System.EventArgs e)
        {
            var userData = this.UserIconGrp.GetSelectedUserData();
            if (null == userData)
            {
                FormMessageBox.Show("ユーザーが選択されていません");
                return;
            }

            if (DialogResult.Yes != FormMessageBox.YesNo("ユーザー[{0}]を削除します。\nよろしいですか？".Fmt(userData.Name)))
            {
                return;
            }

            if (DialogResult.Yes != FormMessageBox.YesNo("この操作は元に戻せません。\n全てのゲームのデータも失われます。\n本当によろしいですか？".Fmt(userData.Name)))
            {
                return;
            }

            // イメージの使用を切り離す.
            // 使用されていると削除できないため.
            var icon = this.UserIconGrp.GetSelectedIcon();
            icon.RemoveImage();

            // ユーザ削除
            userData.Delete();

            FormMessageBox.Show("{0}を削除しました。".Fmt(userData.Name));

            // 再ロード.
            this.ReloadUsers();
        }

        /// <summary>
        /// 共通設定.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCommonConf_Click(object sender, System.EventArgs e)
        {
            var dlg = new FormCommonConf();
            dlg.ShowDialog();
        }
    }
}
