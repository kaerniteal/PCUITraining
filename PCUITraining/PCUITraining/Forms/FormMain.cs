using PCUITCommon;
using PCUITCommon.Users;
using PCUITCommon.Views;
using System;
using System.Windows.Forms;
using TypingExercise;
using TypingExercise.Views;
using TypingExercise.WordSet.PokemonSet;
using static PCUITCommon.Views.UserIcon;

namespace PCUITraining.Forms
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
            SetUserIcons();
        }

        /// <summary>
        /// ユーザーアイコンをセット.
        /// </summary>
        private void SetUserIcons()
        {
            this.UserIconGrp = UserIcon.CreateUserIconGrp();

            foreach (var user in PCUIT.UserDataManager.UserDataList)
            {
                var userIcon = UserIconGrp.CreateUserIcon(user);
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
            var userData = UserIconGrp.GetSelectedUserData();
            if (null == userData)
            {
                MessageBox.Show("ユーザーを選択してください");
                return;
            }

            var wordSet = TypExc.GetWordList(PokemonSet.Name);
            if (null == wordSet)
            {
                return;
            }

            var instance = wordSet.GetGameInstance(userData);
            var formExec = new FormTypExc(instance);
            formExec.ShowDialog();
        }

        /// <summary>
        /// ポケモンタイピング－ゲームデータ表示.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPokeMonTypingDataView_Click(object sender, EventArgs e)
        {
            var userData = UserIconGrp.GetSelectedUserData();
            // ユーザーデータは未選択(null)を許容する.
            var fromDataView = new FormPokemonSetDataViewer(userData);
            fromDataView.ShowDialog();
        }

        /// <summary>
        /// 終了ボタン.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            PCUITraining.Stop();
        }
    }
}
