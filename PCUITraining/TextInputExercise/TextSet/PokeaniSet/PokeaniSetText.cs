namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// ポケモンタイトルデータ.
    /// </summary>
    public class PokeaniSetText : TextBase
    {
        /// <summary>
        /// ソート順.
        /// </summary>
        public int SortID { get; set; }

        /// <summary>
        /// 話数.
        /// </summary>
        public string Episode { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="sortId">ソート順</param>
        /// <param name="episode">話数</param>
        /// <param name="title">タイトル</param>
        public PokeaniSetText(int sortId, string episode, string title) : base(title)
        {
            this.SortID = sortId;
            this.Episode = episode;
        }
    }
}
