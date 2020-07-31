namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// ポケアニライティングゲームデータレコード.
    /// </summary>
    public class PokeaniSetGameDataRecord
    {
        /// <summary>
        /// トータル話数.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// シリーズ.
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// 編.
        /// </summary>
        public string Volume { get; set; }

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
        public int InputedCount { get; set; }

        /// <summary>
        /// 最速タイム.
        /// </summary>
        public long ShortestTime { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PokeaniSetGameDataRecord()
        {
            this.Total = 0;
            this.Series = string.Empty;
            this.Volume = string.Empty;
            this.Episode = string.Empty;
            this.Title = string.Empty;
            this.InputedCount = 0;
            this.ShortestTime = 0;
        }
    }
}
