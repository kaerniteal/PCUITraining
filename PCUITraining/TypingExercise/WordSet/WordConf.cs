namespace TypingExercise.WordSet
{
    /// <summary>
    /// ユーザー毎に切り替え可能なワードセットの設定
    /// </summary>
    public class WordConf
    {
        /// <summary>
        /// 綴りを表示するかどうか.
        /// </summary>
        public bool ShowCorrectSpelling { get; set; }

        /// <summary>
        /// キーボードナビゲーションを表示するかどうか.
        /// </summary>
        public bool ShowKeyboard { get; set; }

        /// <summary>
        /// 指パネルを表示するかどうか.
        /// </summary>
        public bool ShowFinger { get; set; }

        /// <summary>
        /// 単語入力毎に結果を表示するかどうか.
        /// </summary>
        public bool ShowWordResult { get; set; }

        /// <summary>
        /// 綴りを大文字で表示するかどうか.
        /// </summary>
        public bool ShowSpellUpper { get; set; }

        /// <summary>
        /// 綴り候補をすべて表示するか、一つだけ表示するか.
        /// </summary>
        public bool ShowAllSpell { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public WordConf()
        {
            this.ShowCorrectSpelling = true;
            this.ShowKeyboard = true;
            this.ShowFinger = true;
            this.ShowWordResult = true;
            this.ShowSpellUpper = true;
            this.ShowAllSpell = true;
        }
    }
}
