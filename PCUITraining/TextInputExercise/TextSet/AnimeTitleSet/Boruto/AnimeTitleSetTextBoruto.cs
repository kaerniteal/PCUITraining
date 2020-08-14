namespace TextInputExercise.TextSet.AnimeTitleSet.Boruto
{
    /// <summary>
    /// アニタイライティング－アニメタイトルデータ(Boruto).
    /// </summary>
    public class AnimeTitleSetTextBoruto : AnimeTitleSetText
    {
        /// <summary>
        /// 話数.
        /// </summary>
        public int Episode { get; set; }


        /// <summary>
        /// コンストラクタ(JsonI/O用).
        /// </summary>
        public AnimeTitleSetTextBoruto()
        {
            Episode = 0;
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="episode">話数</param>
        /// <param name="title">タイトル</param>
        public AnimeTitleSetTextBoruto(
            int episode,
            string title) : base(title)
        {
            Episode = episode;
        }


        /// <summary>
        /// アニメ名を取得.
        /// </summary>
        /// <returns></returns>
        public override string GetAnimation()
        {
            return @"BORUTO";
        }

        /// <summary>
        /// IDを取得.
        /// </summary>
        /// <returns></returns>
        public override int GetID()
        {
            return this.Episode;
        }

        /// <summary>
        /// エピソードを取得.
        /// </summary>
        /// <returns></returns>
        public override string GetEpisode()
        {
            return $"{this.Episode}話";
        }
    }
}
