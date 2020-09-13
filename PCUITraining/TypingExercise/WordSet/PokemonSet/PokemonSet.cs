using Common.Values;
using PCUITCommon.Users;
using System.Linq;
using TypingExercise.Interfaces;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ワードセット－ポケモンタイピング
    /// </summary>
    public class PokemonSet : WordSetBase
    {
        /// <summary>
        /// セット名.
        /// </summary>
        public static readonly string Name = @"PokemonTyping";


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
        public override Result LoadList()
        {
            this.WordList = PocketMonsterList.GetPockeMonList()
                .Select(pockemon => (WordBase)pockemon)
                .ToList();

            return Result.OK();
        }

        /// <summary>
        /// ゲームインスタンスを取得する.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        /// <returns>ゲームインスタンスインタフェース</returns>
        public override ITypExcGameInstance GetGameInstance(UserData userData)
        {
            return new PokemonSetGameInstance(this, userData);
        }
    }
}
