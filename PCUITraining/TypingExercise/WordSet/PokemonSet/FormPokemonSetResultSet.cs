using Common.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモン総合結果表示ダイアログ.
    /// </summary>
    public partial class FormPokemonSetResultSet : Form
    {
        private int radius { get; set; }
        private int ox { get; set; }
        private int oy { get; set; }

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

            this.radius = (int)(Math.Sqrt(Width * Width + Height * Height) / 2);
            this.ox = Width / 2;
            this.oy = Height / 2;

            this.Region = new Region(new GraphicsPath());

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
            for (var ii = 0; ii < judgResultList.Count; ii++ )
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
            // 円のエフェクトでフォームを描画する.
            Animator.Animate(300, (frame, resolution) =>
            {
                if (!Visible || IsDisposed) return false;
                var graphicsPath = new GraphicsPath();
                var r = radius * frame / resolution;
                graphicsPath.AddEllipse(new Rectangle(ox - r, oy - r, r * 2, r * 2));
                Region = new Region(graphicsPath);
                if (frame == resolution) Region = null;
                return true;
            });

            // 上から順に表示していく.
            Animator.Animate(4000, (frame, frequency) =>
            {
                if (!Visible || IsDisposed)
                {
                    return false;
                }

                // 0～10が得られる.
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
