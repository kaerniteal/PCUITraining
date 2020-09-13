namespace Common.Progress
{
    /// <summary>
    /// 進捗管理 I/F.
    /// </summary>
    public interface IProgressObserver
    {
        /// <summary>
        /// 進捗更新イベント.
        /// </summary>
        /// <param name="progress">進捗(0～100)</param>
        /// <param name="message">メッセージ</param>
        void ProgressNotify(int progress, string message);
    }
}
