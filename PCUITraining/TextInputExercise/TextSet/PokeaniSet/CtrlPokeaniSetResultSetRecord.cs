using Common.Extentions;
using System.Windows.Forms;

namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// ポケアニライティング総合結果表示レコードコントロール.
    /// </summary>
    public partial class CtrlPokeaniSetResultSetRecord : UserControl
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public CtrlPokeaniSetResultSetRecord()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 結果をセット.
        /// </summary>
        /// <param name="textResult">入力結果</param>
        public void SetTextResult(PokeaniSetTextResult textResult)
        {
            this.lblText.Text = textResult.Result.Text;
            this.lblETime.Text = "{0}ms".Fmt(textResult.MeasuredTime);
            this.pBoxUp.Visible = textResult.Update;
        }
    }
}
