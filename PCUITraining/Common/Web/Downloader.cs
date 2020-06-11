using Common.Extentions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;

namespace Common.Web
{
    /// <summary>
    /// Webダウンローダークラス.
    /// </summary>
    public class Downloader
    {
        /// <summary>
        /// Web Client
        /// </summary>
        private WebClient Wc { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="wc">WebClient</param>
        public Downloader(WebClient wc)
        {
            this.Wc = wc;
        }

        /// <summary>
        /// 画像ををリストでダウンロードする.
        /// </summary>
        /// <param name="urls">画像のURLリスト</param>
        /// <returns>取得した画像リスト</returns>
        public List<Bitmap> GetImages(List<string> urls)
        {
            var imageList = new List<Bitmap>();

            foreach (var url in urls)
            {
                var image = this.GetImage(url);
                if (null != image)
                {
                    imageList.Add(image);
                }
            }

            return imageList;
        }

        /// <summary>
        /// 画像をダウンロードする.
        /// </summary>
        /// <param name="url">画像のURL</param>
        /// <returns>取得した画像</returns>
        public Bitmap GetImage(string url)
        {
            try
            {
                using (var stream = this.Wc.OpenRead(url))
                {
                    var bitmap = new Bitmap(stream);
                    stream.Close();
                    return bitmap;
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("画像の取得に失敗しました");
            }

            return null;
        }
    }
}