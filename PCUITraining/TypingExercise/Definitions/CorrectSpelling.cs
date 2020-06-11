using System.Collections.Generic;

namespace TypingExercise.Definitions
{
    /// <summary>
    /// 正しい綴りクラス.
    /// </summary>
    public class CorrectSpelling
    {
        /// <summary>
        /// 文字(1～3 文字)
        /// </summary>
        public string Cha { get; set; }

        /// <summary>
        /// 綴りリスト.
        /// </summary>
        public List<string> Spells { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public CorrectSpelling()
        {
            this.Cha = string.Empty;
            this.Spells = new List<string>();
        }
    }
}
