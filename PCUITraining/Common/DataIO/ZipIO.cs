using Common.Logger;
using Common.Values;
using System;
using System.IO.Compression;
using System.Reflection;

namespace Common.DataIO
{
    /// <summary>
    /// Zipファイルクラス.
    /// </summary>

    public static class ZipIO
    {
        /// <summary>
        /// ログ.
        /// </summary>
        private static Log4netLogger Log = new Log4netLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ZIP解凍.
        /// </summary>
        /// <param name="zipPath">Zipファイルのパス</param>
        /// <param name="extractPath">解凍先フォルダパス</param>
        /// <returns>成否</returns>
        public static Result UnZip(string zipPath, string extractPath)
        {
            try
            {
                using (var archive = ZipFile.Open(zipPath, ZipArchiveMode.Read))
                {
                    archive.ExtractToDirectory(extractPath);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return Result.NG($"Zipファイルの伸長に失敗しました。\n{zipPath}", ex);
            }

            return Result.OK();
        }
    }
}
