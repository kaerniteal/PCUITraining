using Common.Logger;
using Common.Updater.Ver1_0_0;
using Common.Updater.Ver1_0_0.Executors;
using Common.Utilities;
using Common.Values;
using Common.Versions;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Common.Updater
{
    /// <summary>
    /// 更新ツール管理クラス.
    /// </summary>
    public class UpdaterControler
    {
        /// <summary>
        /// ログ.
        /// </summary>
        private static Log4netLogger Log = new Log4netLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// アプリケーションのバージョンチェック情報.
        /// </summary>
        private VerCheckInfoVer1_0_0 AppInfo { get; set; }

        /// <summary>
        /// 更新ツールモジュール名.
        /// </summary>
        private string UpdaterName { get; set; }

        /// <summary>
        /// アプリケーションのバージョンアップチェック後に確定したアーカイブへのURL.
        /// </summary>
        private string AppArchiveUrl { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="appInfo">アプリケーションのバージョンチェック情報</param>
        /// <param name="updaterName">更新ツールのモジュール名</param>
        public UpdaterControler(VerCheckInfoVer1_0_0 appInfo, string updaterName)
        {
            this.AppInfo = appInfo;
            this.UpdaterName = updaterName;
            this.AppArchiveUrl = string.Empty;
        }

        /// <summary>
        /// 更新ツールを更新する.
        /// </summary>
        /// <remarks>時間がかかるので、非同期で実施推奨</remarks>
        /// <param name="updaterUrl">更新ツールのURL：「http://～/latest/」 </param>
        public Result UpdaterUpdate(string updaterUrl)
        {
            Log.Info("更新ツールの更新チェック.");

            // 元バージョン(デフォルトで0.0.0をセット)
            var srcVer = new Ver();

            // 更新ツールバージョン取得.
            var loadResult = Ver.Load($@"{UtilFolder.GetAppFolderPath()}\{this.UpdaterName}\{this.UpdaterName}.{Ver.VER_EXT}");
            if (loadResult.IsOK)
            {
                // 取得出来たらその値を使用.
                srcVer = loadResult.Value;
                Log.Info($@"更新ツールのVersion:{srcVer}");
            }
            else
            {
                Log.Warn($"更新ツールのVersion:取得失敗\n{loadResult.Message}");
            }

            // 更新ツールのバージョンチェック.
            var verCheckInfo = new VerCheckInfoVer1_0_0
            {
                SrcVer = srcVer,
                Url = updaterUrl,
                ModuleName = this.UpdaterName,
                Proxy = this.AppInfo.Proxy,
            };

            Log.Info($@"更新ツールのバージョンチェック");
            Log.Info($@"SrcVer：{verCheckInfo.SrcVer}");
            Log.Info($@"Url：{verCheckInfo.Url}");
            Log.Info($@"ModuleName：{verCheckInfo.ModuleName}");

            // バージョンチェッカー.
            var verChecker = new VerCheckerVer1_0_0(verCheckInfo);
            if (!verChecker.NeedUpdate(out var archiveUrl))
            {
                // 更新不要.
                Log.Info($@"更新ツールの更新不要");
                return Result.OK();
            }

            Log.Info($@"更新ツールの更新開始");

            // 更新ツールを更新するための情報.
            var info = new UpdateInfoVer1_0_0
            {
                Mode = UpdateInfoVer1_0_0.UPDATE_MODE.INSTALL,
                Url = archiveUrl,
                InstallFolderPath = UtilFolder.GetAppFolderPath(),
                AppExecPath = string.Empty,
            };

            Log.Info($@"更新ツールを更新するための情報");
            Log.Info($@"Mode：{info.Mode}");
            Log.Info($@"Url：{info.Url}");
            Log.Info($@"InstallFolderPath：{info.InstallFolderPath}");
            Log.Info($@"AppExecPath：{info.AppExecPath}");

            // 更新ツール更新.
            var updaterUpdater = new UpdaterVer1_0_0(info);
            var updateResult = updaterUpdater.Update();

            Log.Info($@"更新ツールの更新完了");

            return updateResult;
        }

        /// <summary>
        /// アプリケーションのバージョンチェック.
        /// </summary>
        /// <returns>true：より新しいバージョンが存在</returns>
        public bool CheckVersion()
        {
            // バージョンチェッカー.
            var verChecker = new VerCheckerVer1_0_0(this.AppInfo);
            if (verChecker.NeedUpdate(out var archiveUrl))
            {
                this.AppArchiveUrl = archiveUrl;
                return true;
            }

            // 更新不要.
            return false;
        }

        /// <summary>
        /// アプリケーションの更新を更新ツールに委託する.
        /// </summary>
        /// <remarks>
        /// 戻り値がtrueの場合、プロセスを開放する必要があるため、即座にアプリケーションを終了する必要がある。
        /// 時間がかかる終了処理が存在する場合、引数に終了処理を渡して処理させる。
        /// </remarks>
        /// <param name="beforeExitFunc">終了前処理：戻り値は更新継続可否を表す。</param>
        /// <returns>true：委譲成功(要アプリケーション終了)  false：委譲失敗</returns>
        public bool AppUpdate(Func<bool> beforeExitFunc = null)
        {
            try
            {
                var appPath = Application.ExecutablePath;
                var appFolderPath = Path.GetDirectoryName(appPath);

                // アプリケーション更新情報生成.
                var info = new UpdateInfoVer1_0_0
                {
                    Mode = UpdateInfoVer1_0_0.UPDATE_MODE.UPDATE,
                    Url = this.AppArchiveUrl,
                    InstallFolderPath = appFolderPath,
                    AppExecPath = appPath,
                    Proxy = this.AppInfo.Proxy,
                };

                Log.Info($@"アプリケーション更新情報生成");
                Log.Info($@"Mode：{info.Mode}");
                Log.Info($@"Url：{info.Url}");
                Log.Info($@"InstallFolderPath：{info.InstallFolderPath}");
                Log.Info($@"AppExecPath：{info.AppExecPath}");

                // パラメータをローカルファイルとして保存.
                var paramFilePath = $@"{appFolderPath}\{info.GetType().Name}";
                var saveResult = info.Save(paramFilePath);
                if (saveResult.IsNG)
                {
                    // アップデート失敗.
                    Log.Error($"パラメータファイルの保存に失敗しました。\n{saveResult.Message}");
                    return false;
                }

                // 終了前処理を実行.
                var beforeResult = null == beforeExitFunc || beforeExitFunc();
                if (!beforeResult)
                {
                    Log.Warn($"終了前処理がfalseを返したため、更新を中止します。");
                    return false;
                }

                // Updaterを起動する.
                var pInfo = new ProcessStartInfo
                {
                    FileName = $@"{UtilFolder.GetAppFolderPath()}\{this.UpdaterName}\{this.UpdaterName}.exe",
                    Arguments = $@"{UpdateInfoVer1_0_0.FORMAT_VER} {paramFilePath}",
                    UseShellExecute = true,
                };

                Log.Info($@"Updaterを起動する");
                Log.Info($@"FileName：{pInfo.FileName}");
                Log.Info($@"Arguments：{pInfo.Arguments}");

                Process.Start(pInfo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
