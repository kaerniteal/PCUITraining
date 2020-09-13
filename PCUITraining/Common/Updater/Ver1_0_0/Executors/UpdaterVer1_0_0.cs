using Common.DataIO;
using Common.Logger;
using Common.Progress;
using Common.Utilities;
using Common.Values;
using Common.Web;
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace Common.Updater.Ver1_0_0.Executors
{
    /// <summary>
    /// 更新クラス.
    /// </summary>
    public class UpdaterVer1_0_0
    {
        /// <summary>
        /// ログクラス.
        /// </summary>
        private static Log4netLogger Log = new Log4netLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
                ctl?.Begin(4);

                // ワークフォルダを作成(念のためいったん削除してから作成).
                var workFolderPath = $@"{UtilFolder.GetAppFolderPath()}\{WORK_FOLDER_NAME}";
                UtilFolder.DeleteFolder(workFolderPath);
                Directory.CreateDirectory(workFolderPath);

                try
                {
                    var progressLog1 = $@"更新開始 URL:{this.Info.Url}";
                    Log.Info(progressLog1);
                    ctl?.Increment(progressLog1);

                    // ダウンロードしたファイルの保存ファイル名を作成.
                    var fileName = Path.GetFileName(this.Info.Url);
                    var archiveFilePath = $@"{workFolderPath}\{fileName}";

                    // ファイルダウンロード.
                    var dLoader = new Downloader(this.Wc);
                    dLoader.FileDownLoad(this.Info.Url, archiveFilePath);

                    var progressLog2 = $@"保存先:{archiveFilePath}";
                    Log.Info(progressLog2);
                    ctl?.Increment(progressLog2);

                    // アーカイブの伸長.
                    var result = ZipIO.UnZip(archiveFilePath, workFolderPath);
                    if (result.IsNG)
                    {
                        return Result.NG($"アーカイブファイルの伸長に失敗しました。\n{archiveFilePath}", result);
                    }

                    // アーカイブファイルを削除.
                    File.Delete(archiveFilePath);

                    var progressLog3 = @"Zipファイル伸長成功";
                    Log.Info(progressLog3);
                    ctl?.Increment(progressLog3);

                    // Modeによってコピーの仕方が異なる.
                    switch (this.Info.Mode)
                    {
                        // インストールモード.
                        case UpdateInfoVer1_0_0.UPDATE_MODE.INSTALL:

                            // 伸長してできたものを全てインストール先に指定されているフォルダの配下へコピー.
                            Log.Info($@"インストール：{this.Info.InstallFolderPath}");
                            UtilFolder.CopyFolder(workFolderPath, this.Info.InstallFolderPath);
                            break;

                        // アップデートモード.
                        case UpdateInfoVer1_0_0.UPDATE_MODE.UPDATE:

                            // 伸長して出来たのはフォルダ一つだけであることを確認.
                            var folders = Directory.GetDirectories(workFolderPath);
                            if (1 != folders.Length)
                            {
                                return Result.NG($"アーカイブを伸長してできたフォルダが一つだけではありません。\n{archiveFilePath}");
                            }

                            // インストール先が存在するかを確認.
                            if (!Directory.Exists(this.Info.InstallFolderPath))
                            {
                                return Result.NG($"更新先のフォルダが存在しません。\n{this.Info.InstallFolderPath}");
                            }

                            // 伸長してできたフォルダの中身を、全てインストール先へコピー.
                            Log.Info($@"アップデート：{this.Info.InstallFolderPath}");
                            UtilFolder.CopyFolder(folders[0], this.Info.InstallFolderPath);
                            break;
                    }

                    var progressLog4 = @"更新完了";
                    Log.Info(progressLog4);
                    ctl?.Increment(progressLog4);
                }
                finally
                {
                    // ダウンロードフォルダの削除.
                    UtilFolder.DeleteFolder(workFolderPath);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
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
