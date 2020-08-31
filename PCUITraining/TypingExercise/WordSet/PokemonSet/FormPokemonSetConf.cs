using PCUITCommon.Users;
using PCUITCommon.Views;
using System;
using System.Windows.Forms;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモンタイプ－設定ダイアログ.
    /// </summary>
    public partial class FormPokemonSetConf : Form
    {
        /// <summary>
        /// ユーザーデータ.
        /// </summary>
        private UserData UserData { get; set; }

        /// <summary>
        /// ユーザー設定.
        /// </summary>
        private PokemonSetGameData GameData { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        public FormPokemonSetConf(UserData userData)
        {
            InitializeComponent();

            this.UserData = userData;
            this.GameData = PokemonSetGameData.Load(userData);

            this.Init();
        }

        /// <summary>
        /// 設定値で初期化.
        /// </summary>
        private void Init()
        {
            // 共通設定.
            var commonConf = TypExc.Conf;

            // ユーザー設定.
            var userConf = this.GameData.WordConf;

            this.gBoxUser.Text = this.UserData.Name;
            this.gBoxUser.ForeColor = this.UserData.GetFontColor();

            // 画面に反映.
            // 共通.
            this.numKeybordFont.Value = commonConf.KeyBoardFontSize;

            // ユーザー.
            this.bLblShowCorrectSpelling.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, userConf.ShowCorrectSpelling);
            this.bLblShowKeybord.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, userConf.ShowKeyboard);
            this.bLblShowFinger.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, userConf.ShowFinger);
            this.bLblShowWordResult.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, userConf.ShowWordResult);
            this.bLblShowSpellUpper.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, userConf.ShowSpellUpper);
            this.bLblShowAllSpell.Init(BoolLabel.BOOL_LABEL_TYPE.TYPE_YES_NO, userConf.ShowAllSpell);
        }

        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 共通設定.
            var commonConf = TypExc.Conf;

            // ユーザー設定.
            var userConf = this.GameData.WordConf;

            // 設定に反映.
            // 共通.
            commonConf.KeyBoardFontSize = decimal.ToInt32(this.numKeybordFont.Value);

            // ユーザー.
            userConf.ShowCorrectSpelling = this.bLblShowCorrectSpelling.Value;
            userConf.ShowKeyboard = this.bLblShowKeybord.Value;
            userConf.ShowFinger = this.bLblShowFinger.Value;
            userConf.ShowWordResult = this.bLblShowWordResult.Value;
            userConf.ShowSpellUpper = this.bLblShowSpellUpper.Value;
            userConf.ShowAllSpell = this.bLblShowAllSpell.Value;

            // 共通設定保存.
            if (commonConf.Save().IsNG)
            {
                MessageBox.Show("共通設定の保存に失敗しました");
                return;
            }

            if (!this.GameData.Save(this.UserData))
            {
                MessageBox.Show("ユーザー設定の保存に失敗しました");
                return;
            }

            this.Close();
        }
    }
}
