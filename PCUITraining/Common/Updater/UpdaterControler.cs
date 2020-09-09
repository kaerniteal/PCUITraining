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
        /// ログクラス.
        /// </summary>
        private static Log4netLogger Log = new Log4netLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// バージョンチェック情報.
        /// </summary>
        private VerCheckInfoVer1_0_0 Info { get; set; }

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
        /// <param name="info">バージョンチェック情報</param>
        /// <param name="updaterName">更新ツールのモジュール名</param>
        public UpdaterControler(VerCheckInfoVer1_0_0 info, string updaterName)
        {
            this.Info = info;
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

            // 元バージョン
            var srcVer = new Ver();

            // 更新ツールバージョン取得.
            var loadResult = Ver.Load($@"{this.GetUpdaterModuleName()}.version");
            if (loadResult.IsOK)
            {
                // 取得出来たらその値を使用.
                srcVer = loadResult.Value;
                Log.Info($@"更新ツールのVersion:{srcVer}");
            }
            else
            {
                Log.Error($"更新ツールのVersion:取得失敗\n{loadResult.Message}");
            }

            // 更新ツールのバージョンチェック.
            var verCheckInfo = new VerCheckInfoVer1_0_0
            {
                SrcVer = srcVer,
                Url = updaterUrl,
                ModuleName = this.UpdaterName,
                Proxy = this.Info.Proxy,
            };

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
                Url = archiveUrl,
                InstallFolderPath = UtilFolder.GetAppFolderPath(),
                AppExecPath = string.Empty,
            };

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
            var verChecker = new VerCheckerVer1_0_0(this.Info);
            if (verChecker.NeedUpdate(out var archiveUrl))
            {
                this.AppArchiveUrl = archiveUrl;
                return true;
            }

            // 更新不要.
            return false;
        }

        /// <summary>
        /// アプリケーションの更新が必要であれば、更新ツールに委託する.
        /// </summary>
        /// <returns>true：アプリケーションを終了  false：続行</returns>
        public bool AppUpdate()
        {
            try
            {
                var appPath = Application.ExecutablePath;
                var appFolderPath = Path.GetDirectoryName(appPath);
                var installFolderPath = Path.GetDirectoryName(appFolderPath);

                // アプリケーション更新情報生成.
                var info = new UpdateInfoVer1_0_0
                {
                    Url = this.AppArchiveUrl,
                    InstallFolderPath = installFolderPath,
                    AppExecPath = appPath,
                    Proxy = this.Info.Proxy,
                };

                // パラメータをローカルファイルとして保存.
                var paramFilePath = $@"{appFolderPath}\UpdateInfoVer1_0_0";
                var saveResult = info.Save(paramFilePath);
                if (saveResult.IsNG)
                {
                    // アップデート失敗.
                    Log.Error($"パラメータファイルの保存に失敗しました。\n{saveResult.Message}");
                    return false;
                }

                // パラメータを貰って、Updaterに渡して起動する.
                var pInfo = new ProcessStartInfo
                {
                    FileName = $@"{this.GetUpdaterModuleName()}.exe",
                    Arguments = $@"1.0.0 {paramFilePath}",
                    UseShellExecute = true,
                };

                Process.Start(pInfo);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// 拡張子を含まない、更新ツールのパスを取得.
        /// </summary>
        /// <returns>更新ツールのパス(拡張子なし)</returns>
        private string GetUpdaterModuleName()
        {
            return $@"{UtilFolder.GetAppFolderPath()}\{this.UpdaterName}\{this.UpdaterName}";
        }
    }
}
