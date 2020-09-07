using Common.Values;

namespace Common.Conf
{
    /// <summary>
    /// 設定ファイルクラスI/F
    /// </summary>
    public interface IConfBase
    {
        /// <summary>
        /// 設定ファイルパスを返す.
        /// </summary>
        /// <returns>設定ファイルのパス</returns>
        string GetConfFilePath();

        /// <summary>
        /// 保存処理.
        /// </summary>
        /// <returns>成否</returns>
        Result Save();
    }
}
