using Common.Utilities;
using System.Drawing;
using System.Linq;

namespace PCUITCommon.Datas
{
    /// <summary>
    /// イメージを保持する
    /// </summary>
    public class ImageStore
    {
        /// <summary>
        /// 画像リスト.
        /// </summary>
        protected ImageStock[] ImageList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="stockMax">保持する最大数</param>
        public ImageStore(int stockMax)
        {
            this.ImageList = new ImageStock[stockMax];
        }

        /// <summary>
        /// イメージセット.
        /// </summary>
        /// <param name="index">セットするpBoxIndex</param>
        /// <param name="image">画像</param>
        public void SetImage(int index, Bitmap image)
        {
            if (index < this.ImageList.Length)
            {
                this.ImageList[index] = new ImageStock(image);
            }
        }

        /// <summary>
        /// 更新されたイメージの配列を取得.
        /// </summary>
        /// <remarks>更新されていないところはnullを格納</remarks>
        /// <returns></returns>
        public Bitmap[] GetUpdateImages()
        {
            return this.ImageList
                .Select(stock =>
                {
                    if ((null == stock) || (!stock.Update))
                    {
                        return null;
                    }

                    return stock.Image;
                })
                .ToArray();
        }

        /// <summary>
        /// 有効なイメージからランダムで一枚取得する.
        /// </summary>
        /// <returns></returns>
        public Bitmap GetRandomImage()
        {
            // 有効な画像の配列を生成.
            var images = this.ImageList
                .Where(stock => null != stock)
                .Select(stock => stock.Image)
                .ToArray();
            if (0 < images.Length)
            {
                return images.GetRandom();
            }

            return null;
        }

        /// <summary>
        /// 更新対象イメージを格納するインナークラス.
        /// </summary>
        protected class ImageStock
        {
            /// <summary>
            /// 更新要否.
            /// </summary>
            public bool Update { get; set; }

            /// <summary>
            /// 更新対象イメージ.
            /// </summary>
            public Bitmap Image { get; set; }


            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public ImageStock()
            {
                this.Update = false;
                this.Image = null;
            }

            /// <summary>
            /// コンストラクタ.
            /// </summary>
            /// <param name="image">イメージ</param>
            public ImageStock(Bitmap image)
            {
                this.Update = true;
                this.Image = image;
            }
        }
    }
}
