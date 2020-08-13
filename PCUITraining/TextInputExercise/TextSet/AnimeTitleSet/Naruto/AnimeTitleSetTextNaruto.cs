namespace TextInputExercise.TextSet.AnimeTitleSet.Naruto
{
    public class AnimeTitleSetTextNaruto : AnimeTitleSetText
    {
        /// <summary>
        /// 話数.
        /// </summary>
        public int Episode { get; set; }


        /// <summary>
        /// コンストラクタ(JsonI/O用).
        /// </summary>
        public AnimeTitleSetTextNaruto()
        {
            Episode = 0;
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="episode">話数</param>
        /// <param name="title">タイトル</param>
        public AnimeTitleSetTextNaruto(
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
            return @"NARUTO";
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
