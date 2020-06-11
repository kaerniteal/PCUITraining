using System.Collections.Generic;

namespace TypingExercise.Executors
{
    /// <summary>
    /// 実行後の総合結果.
    /// </summary>
    public class SetResult
    {
        /// <summary>
        /// 単語毎の入力結果リスト
        /// </summary>
        public List<WordResult> WordResultList { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public SetResult()
        {
            this.WordResultList = new List<WordResult>();
        }

        /// <summary>
        /// 連続ノーミス数を取得する.
        /// </summary>
        /// <returns></returns>
        public int GetCountConsecutiveNoMiss()
        {
            // MissTypeがゼロの結果を遡ってカウントする.
            var noMissCount = 0;
            for (var ii = this.WordResultList.Count - 1; 0 <= ii; ii--)
            {
                if (0 != this.WordResultList[ii].MissTypeCount)
                {
                    break;
                }

                noMissCount++;
            }

            return noMissCount;
        }
    }
}
