using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // TODO:実装.
        }
    }
}
