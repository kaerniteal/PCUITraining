using Common.Extentions;
using System.Drawing;
using System.Windows.Forms;

namespace TypingExercise.WordSet.PokemonTyping
{
    /// <summary>
    /// ポケモン総合結果表示レコードコントロール.
    /// </summary>
    public partial class PocketMonsterResultSetRecord : UserControl
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PocketMonsterResultSetRecord()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 結果をセット.
        /// </summary>
        /// <param name="judgResult">捕獲判定結果</param>
        public void SetWordResult(PocketMonsterJudgmentResult judgResult)
        {
            // 捕獲判定結果クラスをで捕獲判定を実施.
            this.lblPokemon.Text = judgResult.Name;
            this.lblETime.Text = judgResult.ETimeStr;

            // 最速タイムを更新したかどうか.
            this.pBoxUp.Visible = judgResult.UpdateETime;

            // ボーナス.
            this.lblBonus.Text = @"＋" + judgResult.GetTotalBonus();

            // ゲットかどうか.
            if (judgResult.JudgmentResult)
            {
                this.lblGetted.ForeColor = Color.LimeGreen;
                this.lblGetted.Text = @"ゲットたぜ！";
            }
            else
            {
                this.lblGetted.ForeColor = Color.Red;
                this.lblGetted.Text = @"捕獲失敗";
            }

            if (TypExc.Conf.ShowLogCaptureJudg)
            {
                // 捕獲判定ログを表示.
                this.lblCount.Visible = true;
                this.lblCount.Text = judgResult.JudgLog;
            }
            else
            {
                // 捕獲数を表示.
                this.lblCount.Visible = judgResult.JudgmentResult;
                this.lblCount.Text = @"{0}匹目".Fmt(judgResult.CapturCountStr);
            }

            // イメージ.
            this.pBoxPockMon.Visible = judgResult.JudgmentResult;
            this.pBoxPockMon.Image = judgResult.PockImage;
        }
    }
}
