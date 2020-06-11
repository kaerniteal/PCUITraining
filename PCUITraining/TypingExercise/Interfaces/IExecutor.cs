namespace TypingExercise.Interfaces
{
    /// <summary>
    /// 実行インタフェース
    /// </summary>
    public interface IExecutor
    {
        /// <summary>
        /// 開始.
        /// </summary>
        void Start();

        /// <summary>
        /// 最初から始める.
        /// </summary>
        void Reset();

        /// <summary>
        /// 入力されたKEY
        /// </summary>
        /// <param name="key"></param>
        void InputKey(char key);

        /// <summary>
        /// 終了.
        /// </summary>
        void Stop();
    }
}
