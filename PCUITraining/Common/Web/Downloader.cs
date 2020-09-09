using Common.Logger;
using Common.Values;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Reflection;

namespace Common.Web
{
    /// <summary>
    /// Webダウンローダークラス.
    /// </summary>
    public class Downloader
    {
        /// <summary>
        /// ログクラス.
        /// </summary>
        private static Log4netLogger Log = new Log4netLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
                Log.Error($"{url}の取得に失敗しました\n{ex}");
            }

            return null;
        }

        /// <summary>
        /// ファイルをダウンロードする.
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="savePath">保存先のファイル名</param>
        /// <returns>成否</returns>
        public Result FileDownLoad(string url, string savePath)
        {
            try
            {
                this.Wc.DownloadFile(url, savePath);
            }
            catch (Exception ex)
            {
                return Result.NG($"ファイルのダウンロードに失敗しました。\n{url}", ex);
            }

            return Result.OK();
        }
    }
}