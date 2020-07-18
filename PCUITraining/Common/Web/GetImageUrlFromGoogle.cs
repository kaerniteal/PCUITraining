using Common.Extentions;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Common.Web
{
    /// <summary>
    /// Googleの画像検索を利用して、画像のURLリストを取得する.
    /// </summary>
    public class GetImageUrlFromGoogle : HtmlAnalizerBase
    {
        /// <summary>
        /// Googleの画像検索フォーマット.
        /// </summary>
        private static readonly string GOOGLE_URL_FORMAT = @"https://www.google.com/search?q={0}&tbm=isch&num={1}&safe=high&gbv=1";

        /// <summary>
        /// Googleの画像検索結果HTMLに含まれる、画像へのURLの始まり部分.
        /// </summary>
        private static readonly string GOOGLE_IMAGE_URL_PRE = @"https://encrypted-tbn0.gstatic.com/images";

        /// <summary>
        /// 取得した画像URLのリスト.
        /// </summary>
        private List<string> ImageUrlList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="wc">Web Client</param>
        public GetImageUrlFromGoogle(WebClient wc) : base(wc)
        {
            this.ImageUrlList = new List<string>();
        }

        /// <summary>
        /// Googleの画像検索を利用して、画像のURLリストを取得する
        /// </summary>
        /// <param name="keyword">検索対象キーワード</param>
        /// <param name="count">取得数</param>
        /// <returns>画像へのURLリスト</returns>
        public List<string> GetImageUrls(string keyword, int count)
        {
            var url = GOOGLE_URL_FORMAT.Fmt(keyword, count);

            this.Url(url);

            return this.ImageUrlList;
        }

        /// <summary>
        /// 行解析処理.
        /// </summary>
        /// <param name="line">解析行</param>
        protected override void LineAnalize(string line)
        {
            var httpIndex = line.IndexOf(GOOGLE_IMAGE_URL_PRE);
            if (httpIndex < 0)
            {
                return;
            }

            var httpText = line.Substring(httpIndex);
            var endIndex = httpText.IndexOf("\"");
            if (endIndex < 0)
            {
                return;
            }

            var url = httpText.Substring(0, endIndex);
            this.ImageUrlList.Add(url);
        }
    }
}