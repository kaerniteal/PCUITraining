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

        /// <summary>
        /// 連続ノーミス数を取得する.
        /// </summary>
        /// <returns></returns>
        public int GetCountConsecutiveNoMiss()
        {
            // MissTypeがゼロの結果を遡ってカウントする.
            var noMissCount = 0;
            for (var ii = this.TextResultList.Count - 1; 0 <= ii; ii--)
            {
                if (0 != this.TextResultList[ii].MissTypeCount)
                {
                    break;
                }

                noMissCount++;
            }

            return noMissCount;
        }
    }
}
