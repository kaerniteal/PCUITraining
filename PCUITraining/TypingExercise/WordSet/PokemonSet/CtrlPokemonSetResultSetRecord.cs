using Common.Extentions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモン総合結果表示レコードコントロール.
    /// </summary>
    public partial class CtrlPokemonSetResultSetRecord : UserControl
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public CtrlPokemonSetResultSetRecord()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 結果をセット.
        /// </summary>
        /// <param name="judgResult">捕獲判定結果</param>
        public void SetWordResult(PokemonSetJudgmentResult judgResult)
        {
            var wordResult = judgResult.WordResult;

            // 捕獲判定結果クラスをで捕獲判定を実施.
            this.lblPokemon.Text = wordResult.Word;
            this.lblETime.Text = wordResult.MeasuredTime.ToString();

            // 最速タイムを更新したかどうか.
            this.pBoxUp.Visible = judgResult.UpdateETime;
            Console.WriteLine("Update:" + judgResult.UpdateETime);

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
                this.lblCount.Text = @"{0}匹目".Fmt(judgResult.CapturCount);
            }

            // イメージ.
            this.pBoxPockMon.Visible = judgResult.JudgmentResult;
            this.pBoxPockMon.Image = wordResult.ImageStore.GetRandomImage();

            // マスターボール.
            this.pBoxMasterBoll.Visible = wordResult.UseMasterBoll;
        }
    }
}
