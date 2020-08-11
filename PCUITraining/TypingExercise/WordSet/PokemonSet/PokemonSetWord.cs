using Common.Extentions;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケモンデータ.
    /// </summary>
    public class PokemonSetWord : WordBase
    {
        /// <summary>
        /// ポケモン図鑑No.
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// ポケモン図鑑No.
        /// </summary>
        public int No
        {
            get
            {
                return this.Num.ToInt();
            }
        }

        /// <summary>
        /// コンストラクタ(JsonI/O用).
        /// </summary>
        public PokemonSetWord()
        {
            this.Num = @"000";
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="num">ポケモン図鑑番号</param>
        /// <param name="pocketMonsterName">ポケモンの名前</param>
        public PokemonSetWord(string num, string pocketMonsterName) : base(pocketMonsterName)
        {
            this.Num = num;
        }
    }
}
