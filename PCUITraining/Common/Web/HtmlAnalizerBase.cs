using Common.Extentions;
using Common.Values;
using System.IO;
using System.Net;
using System.Text;

namespace Common.Web
{
    /// <summary>
    /// Htmlを取得してテキストを解析する基底クラス.
    /// </summary>
    public abstract class HtmlAnalizerBase
    {
        /// <summary>
        /// Web Client
        /// </summary>
        private WebClient Wc { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="wc">Web Client</param>
        public HtmlAnalizerBase(WebClient wc)
        {
            this.Wc = wc;
        }

        /// <summary>
        /// Htmlを取得してテキストを解析する.
        /// </summary>
        /// <param name="url">アクセスするURL</param>
        /// <returns>成否</returns>
        protected Result Url(string url)
        {
            try
            {
                this.Wc.Encoding = Encoding.UTF8;
                var html = this.Wc.DownloadString(url);

                // デコードする.
                var decoded = WebUtility.HtmlDecode(html.Trim());

                // 解析の前処理を施す.
                var preparation = this.BeforeAnalize(decoded);

                // 取得したHTMLを解析する処理に預ける.
                this.HtmlAnalize(preparation);
            }
            catch (WebException ex)
            {
                Result.NG(ex);
            }

            return Result.OK();
        }

        /// <summary>
        /// 解析前処理.
        /// </summary>
        /// <param name="html">取得したHTML</param>
        /// <returns>解析に与えるHTML</returns>
        protected virtual string BeforeAnalize(string html)
        {
            return html;
        }

        /// <summary>
        /// HTML解析処理.
        /// </summary>
        /// <param name="html">html</param>
        private void HtmlAnalize(string html)
        {
            if (html.IsEmpty())
            {
                return;
            }

            // 一行ずつ読み込む
            using (var rs = new StringReader(html))
            {
                // 末端まで繰り返す
                while (-1 < rs.Peek())
                {
                    var line = rs.ReadLine().Trim();
                    if (!line.IsEmpty())
                    {
                        // 一行読み込んで解析する.
                        this.LineAnalize(line);
                    }
                }

                rs.Close();
            }
        }

        /// <summary>
        /// 行解析処理.
        /// </summary>
        /// <param name="line">解析行</param>
        protected abstract void LineAnalize(string line);
    }
}