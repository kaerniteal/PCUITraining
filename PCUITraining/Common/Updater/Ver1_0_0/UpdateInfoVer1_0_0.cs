using Common.DataIO;

namespace Common.Updater.Ver1_0_0
{
    /// <summary>
    /// アプリケーション更新情報.
    /// </summary>
    public class UpdateInfoVer1_0_0 : JsonDataBase<UpdateInfoVer1_0_0>
    {
        /// <summary>
        /// ダウンロード元URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// インストールフォルダパス
        /// </summary>
        public string InstallFolderPath { get; set; }

        /// <summary>
        /// インストール後に実行するアプリケーションの実行モジュールのパス.
        /// </summary>
        public string AppExecPath { get; set; }

        /// <summary>
        /// Proxy設定.
        /// </summary>
        public ProxyInfo Proxy { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public UpdateInfoVer1_0_0()
        {
            this.Url = string.Empty;
            this.InstallFolderPath = string.Empty;
            this.AppExecPath = string.Empty;
            this.Proxy = new ProxyInfo();
        }
    }
}
