using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextInputExercise.Executors;

namespace TextInputExercise.TextSet.AnimeTitleSet
{
    /// <summary>
    /// アニタイライティング入力結果.
    /// </summary>
    public class AnimeTitleSetTextResult
    {
        /// <summary>
        /// テキスト入力結果.
        /// </summary>
        public AnimeTitleSetText Result { get; set; }

        /// <summary>
        /// 計測タイム.
        /// </summary>
        public long MeasuredTime { get; set; }

        /// <summary>
        /// 最速更新かどうか.
        /// </summary>
        public bool Update { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="textResult">テキスト入力結果</param>
        /// <param name="update">最速を更新したかどうか</param>
        public AnimeTitleSetTextResult(TextResult textResult, bool update)
        {
            this.Result = textResult.TextBase as AnimeTitleSetText;
            this.MeasuredTime = textResult.MeasuredTime;
            this.Update = update;
        }
    }
}
