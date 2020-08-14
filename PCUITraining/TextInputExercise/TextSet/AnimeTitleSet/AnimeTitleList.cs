using System.Collections.Generic;
using System.Linq;
using TextInputExercise.TextSet.AnimeTitleSet.Boruto;
using TextInputExercise.TextSet.AnimeTitleSet.Naruto;
using TextInputExercise.TextSet.AnimeTitleSet.Pokemon;

namespace TextInputExercise.TextSet.AnimeTitleSet
{
    /// <summary>
    /// アニタイライティング－アニメのサブタイトルリスト
    /// </summary>
    public static class AnimeTitleList
    {
        /// <summary>
        /// アニメタイトルリスト.
        /// </summary>
        private static List<AnimeTitleSetText> TitleList = null;


        /// <summary>
        /// タイトルリストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<AnimeTitleSetText> GetTitleList()
        {
            // ロード済みであればそれを返す.
            if (null != TitleList)
            {
                return TitleList;
            }

            //****************//
            // 未ロード時処理 //
            //****************//

            TitleList = new List<AnimeTitleSetText>();

            // ポケモン.
            if (TIExc.Conf.EnableAnimePokemon)
            {
                var pokemon = AnimeTitleListPokemon.GetPokemonTitleList();
                TitleList.AddRange(pokemon);
            }

            // ナルト.
            if (TIExc.Conf.EnableAnimeNaruto)
            {
                var naruto = AnimeTitleListNaruto.GetNarutoTitleList();
                TitleList.AddRange(naruto);
            }

            // ボルト.
            if (TIExc.Conf.EnableAnimeBoruto)
            {
                var boruto = AnimeTitleListBoruto.GetBorutoTitleList();
                TitleList.AddRange(boruto);
            }

            // ソート.
            TitleList = TitleList
                .OrderBy(rec => rec.GetAnimation())
                .ThenBy(rec => rec.GetID())
                .ToList();

            // トータルを返す.
            return TitleList;
        }
    }
}
