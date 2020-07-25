using TextInputExercise.Executors;

namespace TextInputExercise.Interfaces
{
    /// <summary>
    /// 表示インタフェース
    /// </summary>
    public interface ITIExcViewer
    {
        /// <summary>
        /// 新しい入力対象文字列をセットする.
        /// </summary>
        /// <param name="text">入力対象文字列</param>
        void SetNewText(string text);

        /// <summary>
        /// 入力文字列に対する結果を通知.
        /// </summary>
        /// <param name="correct">正しく入力できている分</param>
        /// <param name="missTypes">ミスタイプ文字</param>
        void ShowInputResult(string correct, string missTypes);

        /// <summary>
        /// 単語入力毎の結果を通知.
        /// </summary>
        void ShowTextResult(TextResult result);

        /// <summary>
        /// 実行後の総合結果を通知.
        /// </summary>
        /// <param name="result">実行結果</param>
        void ShowSetResult(SetResult result);
    }
}
