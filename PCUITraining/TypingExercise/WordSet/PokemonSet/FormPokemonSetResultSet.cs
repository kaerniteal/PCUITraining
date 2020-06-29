using Common.Controls;
using Common.Thread;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモン総合結果表示ダイアログ.
    /// </summary>
    public partial class FormPokemonSetResultSet : Form
    {
        /// <summary>
        /// レコードコントロールリスト
        /// </summary>
        private List<CtrlPokemonSetResultSetRecord> RecordList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public FormPokemonSetResultSet()
        {
            InitializeComponent();

            this.RecordList = new List<CtrlPokemonSetResultSetRecord>();
        }

        /// <summary>
        /// 総合結果表示
        /// </summary>
        /// <param name="judgResultList">捕獲判定結果</param>
        /// <returns>DialogResult</returns>
        public DialogResult ShowSetResultDlg(List<PokemonSetJudgmentResult> judgResultList)
        {
            // 結果をセット.
            this.RecordList = new List<CtrlPokemonSetResultSetRecord>();
            for (var ii = 0; ii < judgResultList.Count; ii++)
            {
                var judgResult = judgResultList[ii];
                var ctrl = new CtrlPokemonSetResultSetRecord();
                ctrl.SetWordResult(judgResult);

                // Load時、上から順にAnimationで表示する為に非表示にしておく.
                ctrl.Visible = false;

                this.RecordList.Add(ctrl);
                this.tableWordResult.Controls.Add(ctrl, 0, ii);
            }

            return this.ShowDialog();
        }

        /// <summary>
        /// ロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PocketMonsterResultSet_Load(object sender, System.EventArgs e)
        {
            // 円形エフェクトで表示する.
            var ace = new AnimationCircleEffect(this);
            ace.FadeIn(500);

            // 4秒かけて上から順に表示していく.
            AnimationTimer.Animate(4000, (frame, frequency) =>
            {
                if (!this.Visible || this.IsDisposed)
                {
                    return false;
                }

                // 割合を整数にして0～10を得る.
                var index = (frame * 10) / frequency;

                // 最初の０の間は除外する.
                if (0 < index)
                {
                    // 0～9にする.
                    index--;
                    if (index < this.RecordList.Count)
                    {
                        this.RecordList[index].Visible = true;
                    }
                }

                return true;
            });
        }

        /// <summary>
        /// つづけるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btonOK_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// おわるボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
