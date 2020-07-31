using TextInputExercise.Executors;

namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// ポケアニライティング入力結果.
    /// </summary>
    public class PokeaniSetTextResult
    {
        /// <summary>
        /// テキスト入力結果.
        /// </summary>
        public PokeaniSetText Result { get; set; }

        /// <summary>
        /// 計測タイム.
        /// </summary>
        public long MeasuredTime { get; set; }

        /// <summary>
        /// 最速更新かどうか.
        /// </summary>
        private bool Update { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="textResult">テキスト入力結果</param>
        /// <param name="update">最速を更新したかどうか</param>
        public PokeaniSetTextResult(TextResult textResult, bool update)
        {
            this.Result = textResult.TextBase as PokeaniSetText;
            this.MeasuredTime = textResult.MeasuredTime;
            this.Update = update;
        }
    }
}
