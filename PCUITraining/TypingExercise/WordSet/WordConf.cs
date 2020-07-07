namespace TypingExercise.WordSet
{
    /// <summary>
    /// ユーザー毎に切り替え可能なワードセットの設定
    /// </summary>
    public class WordConf
    {
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
        /// コンストラクタ.
        /// </summary>
        public WordConf()
        {
            this.ShowKeyboard = true;
            this.ShowFinger = true;
            this.ShowWordResult = true;
            this.ShowSpellUpper = false;
        }
    }
}
