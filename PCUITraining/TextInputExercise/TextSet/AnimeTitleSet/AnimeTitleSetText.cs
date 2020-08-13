namespace TextInputExercise.TextSet.AnimeTitleSet
{
    /// <summary>
    /// アニタイライティング－アニメタイトルデータ.
    /// </summary>
    public abstract class AnimeTitleSetText : TextBase
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public AnimeTitleSetText()
        {
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="title">タイトル.</param>
        public AnimeTitleSetText(string title) : base(title)
        {
        }

        /// <summary>
        /// アニメ名を取得.
        /// </summary>
        /// <returns></returns>
        public abstract string GetAnimation();

        /// <summary>
        /// IDを取得.
        /// </summary>
        /// <returns></returns>
        public abstract int GetID();

        /// <summary>
        /// エピソードを取得.
        /// </summary>
        /// <returns></returns>
        public abstract string GetEpisode();
    }
}
