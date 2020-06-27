using Common.Controls;
using Common.Extentions;
using System.Drawing;
using System.Windows.Forms;
using TypingExercise.Executors;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモン単語入力結果表示ダイアログ.
    /// </summary>
    public partial class FormPokemonSetResultWord : Form
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FormPokemonSetResultWord()
        {
            InitializeComponent();

            this.Opacity = 0;
        }

        /// <summary>
        /// KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PocketMonsterResultWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 何か押下されたら消える.
            this.Close();
        }

        /// <summary>
        /// 単語の入力結果を表示する.
        /// </summary>
        /// <param name="wordResult">単語の入力結果</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowWordResultDlg(WordResult wordResult)
        {
            // ボーナス算出の為に捕獲判定結果クラスを使う.
            var result = PokemonSetJudgmentResult.CreateResultForCalcBonus(wordResult);

            this.lblWord.Text = result.Name;
            this.lblETime.Text = result.ETimeStr;

            // ミスタイプ or 連続ノーミス回数.
            if (0 < result.MissTypeCount)
            {
                this.lblTitleCount.Text = "ミスタイプの回数";
                this.lblCount.Text = result.MissTypeCountStr;
                this.lblCount.ForeColor = Color.Red;
            }
            else
            {
                this.lblTitleCount.Text = "連続ノーミス回数";
                this.lblCount.Text = result.ConsecutiveNoMissCountStr;
                this.lblCount.ForeColor = Color.LimeGreen;
            }

            // ボーナス算出.
            var timeBonus = result.GetETimeBonus();

            // 連続ノーミスボーナス算出.
            var countBonus = result.GetConsecutiveBonus();

            // ボーナスの表示.
            this.lblTitleBonus.Visible = (0 < timeBonus + countBonus);
            this.lblTimeBonus.Visible = (0 < timeBonus);
            this.lblCountBonus.Visible = (0 < countBonus);

            this.lblTimeBonus.Text = "＋{0}".Fmt(timeBonus);
            this.lblCountBonus.Text = "＋{0}".Fmt(countBonus);

            // ダイアログとして表示.
            return this.ShowDialog();
        }

        /// <summary>
        /// ロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PocketMonsterResultWord_Load(object sender, System.EventArgs e)
        {
            var aoe = new AnimationOpacityEffect(this);
            aoe.FadeIn(200);
        }
    }
}
