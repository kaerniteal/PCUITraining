using System.Collections.Generic;
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
            var pokemon = AnimeTitleListPokemon.GetPokemonTitleList();
            TitleList.AddRange(pokemon);

            // ナルト.
            var naruto = AnimeTitleListNaruto.GetNarutoTitleList();
            TitleList.AddRange(naruto);

            // トータルを返す.
            return TitleList;
        }
    }
}
