namespace Common.Logger
{
    /// <summary>
    /// ログWriter I/F
    /// </summary>
    public interface ILogWriter
    {
        /// <summary>
        /// ログの書き込み処理.
        /// </summary>
        /// <param name="log">ログ</param>
        void WriteLine(string log);
    }
}
