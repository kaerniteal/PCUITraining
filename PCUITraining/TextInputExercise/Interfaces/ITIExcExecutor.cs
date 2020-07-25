namespace TextInputExercise.Interfaces
{
    /// <summary>
    /// 実行インタフェース
    /// </summary>
    public interface ITIExcExecutor
    {
        /// <summary>
        /// 開始.
        /// </summary>
        void Start();

        /// <summary>
        /// 入力されたTEXT
        /// </summary>
        /// <param name="text">入力文字列</param>
        void InputText(string text);

        /// <summary>
        /// 終了.
        /// </summary>
        void Stop();
    }
}
