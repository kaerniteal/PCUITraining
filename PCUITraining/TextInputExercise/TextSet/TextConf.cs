namespace TextInputExercise.TextSet
{
    /// <summary>
    /// ユーザー毎に切り替え可能なテキストセットの設定
    /// </summary>
    public class TextConf
    {
        /// <summary>
        /// 文字列入力毎に結果を表示するかどうか.
        /// </summary>
        public bool ShowTextResult { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public TextConf()
        {
            this.ShowTextResult = true;
        }
    }
}
