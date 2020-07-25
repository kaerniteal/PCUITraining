using PCUITCommon.Users;
using System.Linq;
using TextInputExercise.Interfaces;

namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// テキストセット－ポケアニライティング
    /// </summary>
    public class PokeaniSet : TextSetBase
    {
        /// <summary>
        /// セット名.
        /// </summary>
        public static readonly string Name = @"PokeaniWriting";


        /// <summary>
        /// セット名を返す.
        /// </summary>
        public override string GetGameName()
        {
            return Name;
        }

        /// <summary>
        /// 読み込み処理.
        /// </summary>
        /// <returns>成否</returns>
        public override bool LoadList()
        {
            this.WordList = PokeaniTitleList.GetPokemonTitleList()
                .Select(title => (TextBase)title)
                .ToList();

            return true;
        }

        /// <summary>
        /// ゲームインスタンスを取得する.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        /// <returns>ゲームインスタンスインタフェース</returns>
        public override ITIExcGameInstance GetGameInstance(UserData userData)
        {
            return new PokeaniSetGameInstance(this, userData);
        }
    }
}
