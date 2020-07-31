using Common.Extentions;
using PCUITCommon.Datas;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TypingExercise.Views
{
    /// <summary>
    /// イメージ表示パネル
    /// </summary>
    /// <remarks>
    /// 別スレッドからの画像更新にも対応
    /// </remarks>
    public partial class PicturePanel : UserControl
    {
        /// <summary>
        /// ピクチャーボックスリスト.
        /// </summary>
        private List<PictureBox> pBoxList { get; set; }

        /// <summary>
        /// イメージストア.
        /// </summary>
        private ImageStoreDownloadFromGoogle ImageStore { get; set; }


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
        /// 新たなイメージストアを生成し、参照を返す.
        /// </summary>
        /// <returns>新たなイメージストア</returns>
        public ImageStoreDownloadFromGoogle CreateNewImageStore()
        {
            this.ImageStore = new ImageStoreDownloadFromGoogle(this.pBoxList.Count, this.UpdateImage);

            // 全部クリアする.
            foreach (var pbox in this.pBoxList)
            {
                pbox.Image = null;
            }

            return this.ImageStore;
        }

        /// <summary>
        /// 画像更新.
        /// </summary>
        private void UpdateImage()
        {
            // 別スレッドから呼び出された場合の考慮.
            this.UIInvoke(() =>
            {
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
            });
        }
    }
}
