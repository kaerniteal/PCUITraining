using Common.Extentions;
using PCUITCommon.Datas;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TypingExercise.Views
{
    /// <summary>
    /// イメージ表示パネル(
    /// </summary>
    /// <remarks>別スレッドからの画像更新にも対応</remarks>
    public partial class PicturePanel : UserControl
    {
        /// <summary>
        /// ピクチャーボックスリスト.
        /// </summary>
        private List<PictureBox> pBoxList { get; set; }

        /// <summary>
        /// イメージストア.
        /// </summary>
        private ImageStore ImageStore { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PicturePanel()
        {
            InitializeComponent();

            this.TabStop = false;

            // ピクチャーボックスをリスト化しておく.
            this.pBoxList = new List<PictureBox>
            {
                this.pBox00,
                this.pBox01,
                this.pBox02,
                this.pBox03,
                this.pBox04,
                this.pBox10,
                this.pBox11,
                this.pBox12,
                this.pBox13,
                this.pBox14,
            };

            this.CreateNewImageStore();
        }

        /// <summary>
        /// セット可能な画像の最大数.
        /// </summary>
        /// <returns></returns>
        public int GetMaxImageCount()
        {
            return this.pBoxList.Count;
        }

        /// <summary>
        /// イメージセット.
        /// </summary>
        /// <param name="index">セットするpBoxIndex</param>
        /// <param name="image">画像</param>
        public void SetImage(int index, Bitmap image)
        {
            if (null != this.ImageStore)
            {
                this.ImageStore.SetImage(index, image);
            }

            this.UpdateImage();
        }

        /// <summary>
        /// イメージリストセット.
        /// </summary>
        /// <param name="images">画像</param>
        /// <param name="offset">オフセット</param>
        public void SetImages(List<Bitmap> images, int offset = 0)
        {
            if (null != this.ImageStore)
            {
                this.ImageStore.SetImages(images, offset);
            }
        }

        /// <summary>
        /// 新たなイメージストアを生成し、参照を返す.
        /// </summary>
        /// <returns>新たなイメージストア</returns>
        public ImageStore CreateNewImageStore()
        {
            this.ImageStore = new ImageStore(this.pBoxList.Count);

            this.Update();

            return this.ImageStore;
        }

        /// <summary>
        /// 画像更新.
        /// </summary>
        public void UpdateImage()
        {
            // 別スレッドから呼び出された場合
            if (this.InvokeRequired)
            {
                this.BeginInvoke(this.UpdateImage);
                return;
            }

            if (null == this.ImageStore)
            {
                return;
            }

            // 更新されたイメージのリストのみ取得.
            var images = this.ImageStore.GetUpdateImages();

            for (var ii = 0; ii < this.pBoxList.Count && ii < images.Length; ii++)
            {
                var image = images[ii];
                if (null == image)
                {
                    continue;
                }

                this.pBoxList[ii].Image = image;
            }
        }
    }
}
