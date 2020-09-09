using Common.Logger;
using Common.Versions;
using Common.Web;
using System;
using System.Net;
using System.Reflection;

namespace Common.Updater.Ver1_0_0.Executors
{
    /// <summary>
    /// バージョンチェッカー
    /// </summary>
    public class VerCheckerVer1_0_0
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
        /// WebClient.
        /// </summary>
        private WebClient Wc { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="info">バージョンチェック情報.</param>
        public VerCheckerVer1_0_0(VerCheckInfoVer1_0_0 info)
        {
            this.Info = info;
            this.Wc = WebClientCreator.Create(
                this.Info.Proxy.Use,
                this.Info.Proxy.User,
                this.Info.Proxy.Password);
        }

        /// <summary>
        /// 更新が必要かどうかをチェックする.
        /// </summary>
        /// <param name="archiveUrl">更新が必要な場合、ダウンロードすべきアーカイブファイルへのURL</param>
        /// <returns>更新要否</returns>
        public bool NeedUpdate(out string archiveUrl)
        {
            // 途中抜けに備えて初期化.
            archiveUrl = string.Empty;

            try
            {
                // URL
                var dstUrl = $@"{this.Info.Url}{this.Info.ModuleName}.version";
                var json = this.Wc.DownloadString(dstUrl);

                Log.Info($@"バージョン確認：{dstUrl}");

                // デコードする.
                var result = Ver.Deserialize(json);
                if (result.IsNG)
                {
                    Log.Error($"Deserializeに失敗しました。\n{result.Message}");
                    return false;
                }

                var dstVer = result.Value;

                // 更新要否確認.
                if (!this.Info.SrcVer.NeedUpdate(dstVer))
                {
                    // 更新不要な場合は.
                    Log.Info($@"更新不要：SrcVer{this.Info.SrcVer} <> dstVer{dstVer}");
                    return false;
                }

                Log.Info($@"更新が必要：SrcVer{this.Info.SrcVer} <> dstVer{dstVer}");

                // アーカイブURL生成.
                archiveUrl = $@"{this.Info.Url}{this.Info.ModuleName}.{dstVer}.zip";
            }
            catch (Exception ex)
            {
                // 例外発生時は、更新できないと扱う.
                Log.Error(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
