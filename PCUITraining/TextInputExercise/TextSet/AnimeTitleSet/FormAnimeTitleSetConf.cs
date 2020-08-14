using PCUITCommon.Users;
using PCUITCommon.Views;
using System;
using System.Windows.Forms;

namespace TextInputExercise.TextSet.AnimeTitleSet
{
    /// <summary>
    /// ポケモンタイプ－設定ダイアログ.
    /// </summary>
    public partial class FormAnimeTitleSetConf : Form
    {
        /// <summary>
        /// ユーザーデータ.
        /// </summary>
        private UserData UserData { get; set; }

        /// <summary>
        /// ユーザー設定.
        /// </summary>
        private AnimeTitleSetGameData GameData { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        public FormAnimeTitleSetConf(UserData userData)
        {
            InitializeComponent();

            this.UserData = userData;
            this.GameData = AnimeTitleSetGameData.Load(userData);

            this.Init();
        }

        /// <summary>
        /// 設定値で初期化.
        /// </summary>
        private void Init()
        {
            // 共通設定.
            var commonConf = TIExc.Conf;

            // ユーザー設定.
            var userConf = this.GameData.TextConf;

            this.gBoxUser.Text = this.UserData.Name;
            this.gBoxUser.ForeColor = this.UserData.GetFontColor();

            // 画面に反映.
            // 共通.
            this.numMarqueeUpdateInterval.Value = commonConf.MarqueeUpdateInterval;
            this.numMarqueeAmountOfMovement.Value = commonConf.MarqueeAmountOfMovement;
            this.bLblEnableAnimePokemon.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, commonConf.EnableAnimePokemon);
            this.bLblEnableAnimeNaruto.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, commonConf.EnableAnimeNaruto);
            this.bLblEnableAnimeBoruto.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, commonConf.EnableAnimeBoruto);

            // ユーザー.
            this.bLblShowTextResult.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, userConf.ShowTextResult);
        }

        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 共通設定.
            var commonConf = TIExc.Conf;

            // ユーザー設定.
            var userConf = this.GameData.TextConf;

            // 設定に反映.
            // 共通.
            commonConf.MarqueeUpdateInterval = decimal.ToInt32(this.numMarqueeUpdateInterval.Value);
            commonConf.MarqueeAmountOfMovement = decimal.ToInt32(this.numMarqueeAmountOfMovement.Value);
            commonConf.EnableAnimePokemon = this.bLblEnableAnimePokemon.Value;
            commonConf.EnableAnimeNaruto = this.bLblEnableAnimeNaruto.Value;
            commonConf.EnableAnimeBoruto = this.bLblEnableAnimeBoruto.Value;

            // ユーザー.
            userConf.ShowTextResult = this.bLblShowTextResult.Value;

            // 共通設定保存.
            if (!commonConf.Save())
            {
                MessageBox.Show("共通設定の保存に失敗しました");
                return;
            }

            if (!this.GameData.Save(this.UserData))
            {
                MessageBox.Show("ユーザー設定の保存に失敗しました");
                return;
            }

            FormMessageBox.Show(@"この設定の反映には再起動が必要です。");

            this.Close();
        }
    }
}
