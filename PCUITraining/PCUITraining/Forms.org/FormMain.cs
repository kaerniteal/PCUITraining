using System;
using System.Windows.Forms;
using TypingExercise.Datas;
using TypingExercise.WordSet.PocketMonster;
using static TypingExercise.Forms.UserIcon;

namespace TypingExercise.Forms
{
    /// <summary>
    /// メインフォーム.
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// ユーザーアイコングループ.
        /// </summary>
        private UserIconGrp UserIconGrp { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            // ユーザーアイコンをセット.
            this.SetUserIcons();
        }

        /// <summary>
        /// ユーザーアイコンをセット.
        /// </summary>
        private void SetUserIcons()
        {
            this.UserIconGrp = UserIcon.CreateUserIconGrp();

            foreach (var user in PCUIT.UserDataManager.UserDataList)
            {
                var userIcon = this.UserIconGrp.CreateUserIcon(user);
                this.flowUserSelect.Controls.Add(userIcon);
            }
        }

        /// <summary>
        /// ポケモンタイピング.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPokeMonTyping_Click(object sender, EventArgs e)
        {
            var userData = this.GetUserData();
            if (null == userData)
            {
                return;
            }

            var wordSet = PCUIT.TypExc.GetWordList(PocketMonsterSet.Name);
            var formExec = new FormTypExc(wordSet, userData);
            formExec.ShowDialog();
        }

        /// <summary>
        /// ポケモンタイピング－ゲームデータ表示.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPokeMonTypingDataView_Click(object sender, EventArgs e)
        {
            var fromDataView = new FormPocketMonsterDataViewer();
            fromDataView.ShowDialog();
        }

        /// <summary>
        /// 終了ボタン.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            PCUIT.Stop();
        }

        /// <summary>
        /// ユーザーデータを取得する.
        /// </summary>
        /// <returns></returns>
        private UserData GetUserData()
        {
            // 現在画面で選択されているユーザーデータを取得する.
            var userData = this.UserIconGrp.GetSelectedUserData();
            if (null == userData)
            {
                MessageBox.Show("ユーザーを選択してください");
                return null;
            }

            return userData;
        }
    }
}
