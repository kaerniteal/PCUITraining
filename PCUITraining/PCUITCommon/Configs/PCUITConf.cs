using Common.Conf;

namespace PCUITCommon.Configs
{
    /// <summary>
    /// PCUITの設定クラス.
    /// </summary>
    public class PCUITConf : ConfBase<PCUITConf>
    {
        /// <summary>
        /// 設定ファイルパスを返す.
        /// </summary>
        /// <returns>設定ファイルのパス</returns>
        public override string GetConfFilePath()
        {
            return @".\Conf\PCUIT.conf";
        }

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        public override void SetDefault()
        {
            // デフォルトはここで与える.
            this.IsDebug = false;

            this.EnableWeb = true;
            this.ProxyUse = false;
            this.ProxyId = string.Empty;
            this.ProxyPassword = string.Empty;
        }

        /// <summary>
        /// デバッグモードかどうか.
        /// </summary>
        public bool IsDebug { get; set; }

        /// <summary>
        /// Webの有効/無効.
        /// </summary>
        public bool EnableWeb { get; set; }

        /// <summary>
        /// Proxyを使用するかどうか.
        /// </summary>
        public bool ProxyUse { get; set; }

        /// <summary>
        /// ProxyのID
        /// </summary>
        public string ProxyId { get; set; }

        /// <summary>
        /// ProxyのPassword
        /// </summary>
        public string ProxyPassword { get; set; }
    }
}
