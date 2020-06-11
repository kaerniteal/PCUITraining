using Common.Extentions;

namespace TypingExercise.WordSet.PokemonTyping
{
    /// <summary>
    /// ポケモンデータ.
    /// </summary>
    public class PocketMonsterWord : WordBase
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
        /// コンストラクタ.
        /// </summary>
        /// <param name="num">ポケモン図鑑番号</param>
        /// <param name="pocketMonsterName">ポケモンの名前</param>
        public PocketMonsterWord(string num, string pocketMonsterName) : base(pocketMonsterName)
        {
            this.Num = num;
        }
    }
}
