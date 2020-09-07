using System.Net;

namespace Common.Web
{
    /// <summary>
    /// Web Client のFactory
    /// </summary>
    public static class WebClientCreator
    {
        /// <summary>
        /// WebClientを生成する.
        /// </summary>
        /// <param name="user">ユーザー</param>
        /// <param name="password">パスワード</param>
        /// <returns>WebClient</returns>
        public static WebClient Create(bool useSystemProxy, string user, string password)
        {
            // パスカル事務所でいくつかのアクセスの際にSSL証明のエラーが出たことの対応.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Webクライアントを作成.
            var wc = new WebClient();

            // システムProxyの設定
            if (useSystemProxy)
            {
                var proxy = WebRequest.GetSystemWebProxy();
                proxy.Credentials = new NetworkCredential(user, password);
                wc.Proxy = proxy;
            }

            return wc;
        }
    }
}
