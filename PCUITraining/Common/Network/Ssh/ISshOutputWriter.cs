namespace Common.Network.Ssh
{
    /// <summary>
    /// SSHの出力を書き込むI/F
    /// </summary>
    public interface ISshOutputWriter
    {
        /// <summary>
        /// 出力を書き込む.
        /// </summary>
        /// <param name="message"></param>
        void Write(string message);
    }
}
