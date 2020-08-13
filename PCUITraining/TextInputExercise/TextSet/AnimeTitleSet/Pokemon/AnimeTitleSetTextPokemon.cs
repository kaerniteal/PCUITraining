using Common.Extentions;

namespace TextInputExercise.TextSet.AnimeTitleSet.Pokemon
{
    /// <summary>
    /// アニタイライティング－アニメタイトルデータ(ポケモン).
    /// </summary>
    public class AnimeTitleSetTextPokemon : AnimeTitleSetText
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
        public AnimeTitleSetTextPokemon()
        {
            Total = 0;
            Series = string.Empty;
            Volume = string.Empty;
            Episode = string.Empty;
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="total">トータル話数</param>
        /// <param name="series">シリーズ</param>
        /// <param name="volume">編</param>
        /// <param name="episode">話数</param>
        /// <param name="title">タイトル</param>
        public AnimeTitleSetTextPokemon(
            int total,
            string series,
            string volume,
            string episode,
            string title) : base(title)
        {
            Total = total;
            Series = series;
            Volume = volume;
            Episode = episode;
        }


        /// <summary>
        /// アニメ名を取得.
        /// </summary>
        /// <returns></returns>
        public override string GetAnimation()
        {
            return "ポケットモンスター";
        }

        /// <summary>
        /// IDを取得.
        /// </summary>
        /// <returns></returns>
        public override int GetID()
        {
            return this.Total;
        }

        /// <summary>
        /// エピソードを取得.
        /// </summary>
        /// <returns></returns>
        public override string GetEpisode()
        {
            return this.Volume.IsEmpty()
                ? $"{this.Series} {this.Episode}"
                : $"{this.Series} 【{this.Volume}】 {this.Episode}";
        }
    }
}
