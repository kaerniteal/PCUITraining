namespace Common.Updater.Ver1_0_0
{
    /// <summary>
    /// Proxy設定.
    /// </summary>
    public class ProxyInfo
    {
        /// <summary>
        /// Proxyを使用するかどうか.
        /// </summary>
        public bool Use { get; set; }

        /// <summary>
        /// Proxyのユーザー.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Proxyのパスワード.
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ProxyInfo()
        {
            this.Use = false;
            this.User = string.Empty;
            this.Password = string.Empty;
        }
    }
}
