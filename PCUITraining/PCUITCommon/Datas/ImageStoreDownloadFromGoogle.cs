using Common.Web;
using System;
using System.Threading.Tasks;

namespace PCUITCommon.Datas
{
    /// <summary>
    /// イメージをGoogleからダウンロードして保持する
    /// </summary>
    public class ImageStoreDownloadFromGoogle : ImageStore
    {
        /// <summary>
        /// 画像をロードする都度呼び出すコールバック.
        /// </summary>
        private Action OnLoad { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="stockMax">保持する最大数</param>
        /// <param name="onLoad">画像をロードする都度呼び出すコールバック</param>
        public ImageStoreDownloadFromGoogle(int stockMax, Action onLoad = null) : base(stockMax)
        {
            this.OnLoad = onLoad;
        }

        /// <summary>
        /// 画像をGoogleからダウンロードしてストアする.
        /// </summary>
        /// <param name="keyword">検索文字列</param>
        public void DownLoadFromGoogle(string keyword)
        {
            // 読み込み処理を別スレッドで実行.
            Task.Run(() =>
            {
                // WebClientを生成.
                var wc = PCUIT.CreateWebClient();

                // 画像URLをGoogleから取得.
                var google = new GetImageUrlFromGoogle(wc);
                var urls = google.GetImageUrls(keyword, this.ImageList.Length);

                // 画像URLから画像データを取得.
                var downloader = new Downloader(wc);
                for (var ii = 0; ii < urls.Count; ii++)
                {
                    // 一枚ダウンロードして.
                    var image = downloader.GetImage(urls[ii]);

                    // イメージコンポーネントにセットする
                    // 非同期更新なため、このイメージコンポーネントが最新のコンポーネントとは限らないが、セットする
                    this.SetImage(ii, image);

                    // ロードイベントを呼び出す.
                    this.OnLoad?.Invoke();
                }
            });
        }
    }
}
