using PCUITCommon.Users;
using PCUITCommon.Views;
using System;
using System.Windows.Forms;

namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    /// <summary>
    /// ポケモンタイプ－設定ダイアログ.
    /// </summary>
    public partial class FormInsectCollectingSetConf : Form
    {
        /// <summary>
        /// ユーザーデータ.
        /// </summary>
        private UserData UserData { get; set; }

        /// <summary>
        /// ユーザー設定.
        /// </summary>
        private InsectCollectingSetGameData GameData { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        public FormInsectCollectingSetConf(UserData userData)
        {
            InitializeComponent();

            this.UserData = userData;
            this.GameData = InsectCollectingSetGameData.Load(userData);

            this.Init();
        }

        /// <summary>
        /// 設定値で初期化.
        /// </summary>
        private void Init()
        {
            // 共通設定.
            var commonConf = MusExc.Conf;

            // ユーザー設定.
            var userConf = this.GameData.MusExcUserConf;

            this.gBoxUser.Text = this.UserData.Name;
            this.gBoxUser.ForeColor = this.UserData.GetFontColor();

            // 画面に反映.
            // 共通.
            this.numViewUpdateWait.Value = commonConf.ViewUpdateWait;
            this.numUnitMax.Value = commonConf.UnitMax;
            this.bLblEnableDifficultyVeryEasy.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, commonConf.EnableDifficultyVeryEasy);
            this.bLblEnableDifficultyEasy.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, commonConf.EnableDifficultyEasy);
            this.bLblEnableDifficultyNormal.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, commonConf.EnableDifficultyNormal);
            this.bLblEnableDifficultyHard.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, commonConf.EnableDifficultyHard);
            this.bLblEnableDifficultyVeryHard.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, commonConf.EnableDifficultyVeryHard);

            // ユーザー設定.
            this.bLblUseCustomMouseIcon.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, userConf.UseCustomMouseIcon);
        }

        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 共通設定.
            var commonConf = MusExc.Conf;

            // ユーザー設定.
            var userConf = this.GameData.MusExcUserConf;

            // 設定に反映.
            // 共通.
            commonConf.ViewUpdateWait = decimal.ToInt32(this.numViewUpdateWait.Value);
            commonConf.UnitMax = decimal.ToInt32(this.numUnitMax.Value);
            commonConf.EnableDifficultyVeryEasy = this.bLblEnableDifficultyVeryEasy.Value;
            commonConf.EnableDifficultyEasy = this.bLblEnableDifficultyEasy.Value;
            commonConf.EnableDifficultyNormal = this.bLblEnableDifficultyNormal.Value;
            commonConf.EnableDifficultyHard = this.bLblEnableDifficultyHard.Value;
            commonConf.EnableDifficultyVeryHard = this.bLblEnableDifficultyVeryHard.Value;

            // ユーザー設定.
            userConf.UseCustomMouseIcon = this.bLblUseCustomMouseIcon.Value;

            // 共通設定保存.
            if (commonConf.Save().IsNG)
            {
                MessageBox.Show("共通設定の保存に失敗しました");
                return;
            }

            // ユーザー設定.
            if (!this.GameData.Save(this.UserData))
            {
                MessageBox.Show("ユーザー設定の保存に失敗しました");
                return;
            }

            this.Close();
        }
    }
}
