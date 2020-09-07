using Common.DataIO;
using Common.Progress;
using Common.Utilities;
using Common.Values;
using Common.Web;
using System;
using System.IO;
using System.Net;

namespace Common.Updater.Ver1_0_0.Executors
{
    /// <summary>
    /// 更新クラス.
    /// </summary>
    public class UpdaterVer1_0_0
    {
        /// <summary>
        /// 一時フォルダ名.
        /// </summary>
        public static readonly string WORK_FOLDER_NAME = @"Update";

        /// <summary>
        /// アプリケーション更新情報.
        /// </summary>
        private UpdateInfoVer1_0_0 Info { get; set; }

        /// <summary>
        /// WebClient.
        /// </summary>
        private WebClient Wc { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="info">更新情報</param>
        public UpdaterVer1_0_0(UpdateInfoVer1_0_0 info)
        {
            this.Info = info;
            this.Wc = WebClientCreator.Create(
                this.Info.Proxy.Use,
                this.Info.Proxy.User,
                this.Info.Proxy.Password);
        }

        /// <summary>
        /// 更新処理.
        /// </summary>
        /// <param name="ctl">進捗管理：管理したい場合は渡す。進捗管理しない場合はnull許容</param>
        /// <returns>成否</returns>
        public Result Update(ProgressCtl ctl = null)
        {
            try
            {
                ctl?.Begin(5);

                // ワークフォルダを作成(念のためいったん削除してから作成).
                var workFolderPath = $@"{UtilFolder.GetAppFolderPath()}\{WORK_FOLDER_NAME}";
                UtilFolder.DeleteFolder(workFolderPath);
                Directory.CreateDirectory(workFolderPath);

                try
                {
                    ctl?.Increment();

                    // ダウンロードしたファイルの保存ファイル名を作成.
                    var fileName = Path.GetFileName(this.Info.Url);
                    var archiveFilePath = $@"{workFolderPath}\{fileName}";

                    // ファイルダウンロード.
                    var dLoader = new Downloader(this.Wc);
                    dLoader.FileDownLoad(this.Info.Url, archiveFilePath);

                    ctl?.Increment();

                    // アーカイブの伸長.
                    if (ZipIO.UnZip(archiveFilePath, workFolderPath).IsNG)
                    {
                        return Result.NG($"アーカイブファイルの伸長に失敗しました。\n{archiveFilePath}");
                    }

                    ctl?.Increment();

                    // アーカイブファイルを削除.
                    File.Delete(archiveFilePath);

                    ctl?.Increment();

                    // 伸長してできたものをすべてインストール先へコピー.
                    UtilFolder.CopyFolder(workFolderPath, this.Info.InstallFolderPath);

                    ctl?.Increment();
                }
                finally
                {
                    // ダウンロードフォルダの削除.
                    UtilFolder.DeleteFolder(workFolderPath);
                }
            }
            catch (Exception ex)
            {
                return Result.NG(ex);
            }
            finally
            {
                ctl?.Finish();
            }

            return Result.OK();
        }
    }
}
