using MouseExercise;
using MouseExercise.MusExcSet.InsectCollectingSet;
using MouseExercise.Views;
using PCUITCommon.Views;
using System;
using System.Windows.Forms;
using TextInputExercise;
using TextInputExercise.TextSet.PokeaniSet;
using TextInputExercise.Views;
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
            this.UserIconGrp = this.userSelector.SetUserIcons();
        }

        /// <summary>
        /// 設定ボタン.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pBoxConfig_Click(object sender, EventArgs e)
        {
            var dlg = new FormSetting();
            dlg.ShowDialog();
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
                FormMessageBox.Show("ユーザーを選択してください");
                return;
            }

            var wordSet = TypExc.GetWordSet(PokemonSet.Name);
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
            var formDataView = new FormPokemonSetDataViewer(userData);
            formDataView.ShowDialog();
        }

        /// <summary>
        /// ポケモンタイピング－データ交換.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPokeMonTypingReciprocate_Click(object sender, EventArgs e)
        {
            var formReciprocate = new FormPokemonSetReciprocate();
            formReciprocate.ShowDialog();
        }

        /// <summary>
        /// マウスで昆虫採集.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsectCollecting_Click(object sender, EventArgs e)
        {
            var userData = UserIconGrp.GetSelectedUserData();
            if (null == userData)
            {
                FormMessageBox.Show("ユーザーを選択してください");
                return;
            }

            var musExcSet = MusExc.GetMusExcSet(InsectCollectingSet.Name);
            var gameInstance = musExcSet.GetGameInstance(userData);
            var formExec = new FormMusExc(gameInstance);
            formExec.ShowDialog();
        }

        /// <summary>
        /// ポケモンライティング.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPokeMonWriting_Click(object sender, EventArgs e)
        {
            var userData = UserIconGrp.GetSelectedUserData();
            if (null == userData)
            {
                FormMessageBox.Show("ユーザーを選択してください");
                return;
            }

            var textSet = TIExc.GetTextSet(PokeaniSet.Name);
            if (null == textSet)
            {
                return;
            }

            var instance = textSet.GetGameInstance(userData);
            var formExec = new FormTIExc(instance);
            formExec.ShowDialog();
        }

        /// <summary>
        /// ポケモンライティング－ゲームデータ表示.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPokeMonWritingDataView_Click(object sender, EventArgs e)
        {
            var userData = UserIconGrp.GetSelectedUserData();

            // ユーザーデータは未選択(null)を許容する.
            var formDataView = new FormPokeaniSetDataViewer(userData);
            formDataView.ShowDialog();
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
