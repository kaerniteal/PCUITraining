namespace TextInputExercise.TextSet.AnimeTitleSet
{
    /// <summary>
    /// アニタイライティングゲームデータレコード.
    /// </summary>
    public class AnimeTitleSetGameDataRecord
    {
        /// <summary>
        /// アニメ名.
        /// </summary>
        public string Animation { get; set; }

        /// <summary>
        /// ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// エピソード.
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
        public AnimeTitleSetGameDataRecord()
        {
            this.Animation = string.Empty;
            this.ID = 0;
            this.Episode = string.Empty;
            this.Title = string.Empty;
            this.InputedCount = 0;
            this.ShortestTime = 0;
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="pokeAni">ポケモンタイトルデータ</param>
        public AnimeTitleSetGameDataRecord(AnimeTitleSetText pokeAni)
        {
            Animation = pokeAni.GetAnimation();
            ID = pokeAni.GetID();
            Episode = pokeAni.GetEpisode();
            Title = pokeAni.Text;
            this.InputedCount = 0;
            this.ShortestTime = 0;
        }
    }
}
