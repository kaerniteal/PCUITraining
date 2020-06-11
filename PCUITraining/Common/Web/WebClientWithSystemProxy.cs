using System.Net;

namespace Common.Web
{
    /// <summary>
    /// システムのProxy設定を使用するWebClient
    /// </summary>
    public class WebClientWithSystemProxy : WebClient
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public WebClientWithSystemProxy()
        {
            //プロキシの設定
            var proxy = WebRequest.GetSystemWebProxy();
            this.Proxy = proxy;
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="user">ユーザー</param>
        /// <param name="password">パスワード</param>
        public WebClientWithSystemProxy(string user, string password)
        {
            //プロキシの設定
            var proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = new NetworkCredential(user, password);
            this.Proxy = proxy;
        }
    }
}
