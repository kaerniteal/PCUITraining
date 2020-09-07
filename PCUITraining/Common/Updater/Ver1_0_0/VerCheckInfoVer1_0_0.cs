using Common.Versions;

namespace Common.Updater.Ver1_0_0
{
    /// <summary>
    /// バージョンチェック情報.
    /// </summary>
    public class VerCheckInfoVer1_0_0
    {
        /// <summary>
        /// 比較元バージョン.
        /// </summary>
        public Ver SrcVer { get; set; }

        /// <summary>
        /// 比較先URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// モジュール名.
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// プロクシ情報.
        /// </summary>
        public ProxyInfo Proxy { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public VerCheckInfoVer1_0_0()
        {
            this.Url = string.Empty;
            this.ModuleName = string.Empty;
            this.Proxy = new ProxyInfo();
        }
    }
}
