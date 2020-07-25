using System;
using System.Collections.Generic;

namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// ポケアニライティングゲームデータレコード.
    /// </summary>
    public class PokeaniSetGameDataRecord
    {
        /// <summary>
        /// 話数.
        /// </summary>
        public string Episode { get; set; }

        /// <summary>
        /// タイトル.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 入力回数.
        /// </summary>
        public int CapturCount { get; set; }

        /// <summary>
        /// 最速タイム.
        /// </summary>
        public long ShortestTime { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PokeaniSetGameDataRecord()
        {
            this.Episode = string.Empty;
            this.Title = string.Empty;
            this.CapturCount = 0;
            this.ShortestTime = 0;
        }
    }
}
