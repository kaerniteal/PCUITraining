using Common.Controls.ProgressBar;
using MouseExercise;
using MouseExercise.MusExcSet.InsectCollectingSet;
using MouseExercise.Views;
using PCUITCommon.Views;
using System;
using System.Windows.Forms;
using TextInputExercise;
using TextInputExercise.TextSet.AnimeTitleSet;
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

            // ロード完了まで触れないように.
            this.tableMain.Enabled = false;
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // プログレスバー付き非同期処理.
            var dlg = new FromProgressBar((ctl) =>
            {
                PCUITraining.SetUp(ctl);
            });

            // プログレスバー表示.
            // モーダルで表示するが、非同期処理終了後に自動的に閉じられる.
            dlg.ShowDialog();

            // 非同期処理終了後に実行
            // 画面を有効化.
            this.tableMain.Enabled = true;
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

            this.UserIconGrp = this.userSelector.SetUserIcons();
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
        /// マウスで昆虫採集－ゲームデータ表示..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsectCollectingDataView_Click(object sender, EventArgs e)
        {
            var userData = UserIconGrp.GetSelectedUserData();

            // ユーザーデータは未選択(null)を許容する.
            var formDataView = new FormInsectCollectingSetDataViewer(userData);
            formDataView.ShowDialog();
        }

        /// <summary>
        /// アニタイライティング.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAniTtlWriting_Click(object sender, EventArgs e)
        {
            var userData = UserIconGrp.GetSelectedUserData();
            if (null == userData)
            {
                FormMessageBox.Show("ユーザーを選択してください");
                return;
            }

            var textSet = TIExc.GetTextSet(AnimeTitleSet.Name);
            if (null == textSet)
            {
                return;
            }

            var instance = textSet.GetGameInstance(userData);
            var formExec = new FormTIExc(instance);
            formExec.ShowDialog();
        }

        /// <summary>
        /// アニタイライティング－ゲームデータ表示.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAniTtlWritingDataView_Click(object sender, EventArgs e)
        {
            var userData = UserIconGrp.GetSelectedUserData();

            // ユーザーデータは未選択(null)を許容する.
            var formDataView = new FormAnimeTitleSetDataViewer(userData);
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
