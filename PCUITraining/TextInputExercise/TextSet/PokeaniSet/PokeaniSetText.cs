namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// ポケモンタイトルデータ.
    /// </summary>
    public class PokeaniSetText : TextBase
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
        /// ○○編.
        /// </summary>
        public string Volume { get; set; }

        /// <summary>
        /// 話数.
        /// </summary>
        public string Episode { get; set; }


        /// <summary>
        /// コンストラクタ(JsonI/O用).
        /// </summary>
        public PokeaniSetText()
        {
            this.Total = 0;
            this.Series = string.Empty;
            this.Volume = string.Empty;
            this.Episode = string.Empty;
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="total">トータル話数</param>
        /// <param name="series">シリーズ</param>
        /// <param name="volume">編</param>
        /// <param name="episode">話数</param>
        /// <param name="title">タイトル</param>
        public PokeaniSetText(
            int total,
            string series,
            string volume,
            string episode,
            string title) : base(title)
        {
            this.Total = total;
            this.Series = series;
            this.Volume = volume;
            this.Episode = episode;
        }
    }
}
