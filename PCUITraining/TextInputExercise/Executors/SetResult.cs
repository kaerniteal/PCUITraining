using System.Collections.Generic;

namespace TextInputExercise.Executors
{
    /// <summary>
    /// 実行後の総合結果.
    /// </summary>
    public class SetResult
    {
        /// <summary>
        /// 単語毎の入力結果リスト
        /// </summary>
        public List<TextResult> TextResultList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public SetResult()
        {
            this.TextResultList = new List<TextResult>();
        }
    }
}
