using Common.Threads;
using Common.WinForms;
using Common.WinForms.Animation;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// ポケアニライティング総合結果表示ダイアログ.
    /// </summary>
    public partial class FormPokeaniSetResultSet : Form
    {
        /// <summary>
        /// 結果表示レコードコントロールリスト.
        /// </summary>
        private List<CtrlPokeaniSetResultSetRecord> CtrlList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="resultList"></param>
        public FormPokeaniSetResultSet(List<PokeaniSetTextResult> resultList)
        {
            InitializeComponent();

            this.CtrlList = new List<CtrlPokeaniSetResultSetRecord>();

            // 結果をセット.
            for (var ii = 0; ii < resultList.Count; ii++)
            {
                var judgResult = resultList[ii];
                var ctrl = new CtrlPokeaniSetResultSetRecord();
                ctrl.SetTextResult(judgResult);

                // Load時、上から順にAnimationで表示する為に非表示にしておく.
                ctrl.Visible = false;

                this.CtrlList.Add(ctrl);
                this.tableLayoutPanel.Controls.Add(ctrl, 0, ii);
            }
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPokeaniSetResultSet_Load(object sender, System.EventArgs e)
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
                    if (index < this.CtrlList.Count)
                    {
                        this.CtrlList[index].Visible = true;
                    }
                }

                return true;
            });
        }
    }
}
