using Common.Extentions;
using PCUITCommon.Datas;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TextInputExercise.Views
{
    /// <summary>
    /// イメージ表示パネル
    /// </summary>
    /// <remarks>
    /// 別スレッドからの画像更新にも対応
    /// </remarks>
    public partial class MarqueePanel : UserControl
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
        /// 画像のベース座標
        /// </summary>
        private int BaseX { get; set; }

        /// <summary>
        /// タイマ.
        /// </summary>
        private Timer Timer { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MarqueePanel()
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
                this.pBox05,
                this.pBox06,
                this.pBox07,
                this.pBox08,
                this.pBox09,
            };

            this.CreateNewImageStore();

            this.BaseX = 0;
            this.Timer = null;
        }

        /// <summary>
        /// サイズ変更.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarqueePanel_Resize(object sender, System.EventArgs e)
        {
            var h = this.Size.Height;
            foreach (var pbox in this.pBoxList)
            {
                pbox.Size = new Size(h, h);
            }
        }

        /// <summary>
        /// Marqueeを開始.
        /// </summary>
        public void StartMarquee()
        {
            // 既に存在する場合は停止.
            if (null != this.Timer)
            {
                this.Timer.Stop();
            }

            // 新たなタイマを作成して.
            this.Timer = new Timer()
            {
                Interval = TIExc.Conf.MarqueeUpdateInterval,
            };

            // イベントハンドラを定義.
            this.Timer.Tick += (sender, e) =>
            {
                this.BaseX -= TIExc.Conf.MarqueeAmountOfMovement;
                this.UpdatePosition();
            };

            // Marquee開始.
            this.Timer.Start();
        }

        /// <summary>
        /// Marqueeを停止.
        /// </summary>
        public void StopMarquee()
        {
            if (null == this.Timer)
            {
                return;
            }

            this.Timer.Stop();
            this.Timer.Dispose();
            this.Timer = null;
        }

        /// <summary>
        /// 新たなイメージストアを生成し、参照を返す.
        /// </summary>
        /// <returns>新たなイメージストア</returns>
        public ImageStoreDownloadFromGoogle CreateNewImageStore()
        {
            this.ImageStore = new ImageStoreDownloadFromGoogle(this.pBoxList.Count, this.UpdateImage);

            foreach (var pbox in this.pBoxList)
            {
                // 全部クリアする.
                pbox.Image = null;
            }

            // 位置を戻す.
            this.BaseX = 0;

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

        /// <summary>
        /// 位置更新.
        /// </summary>
        private void UpdatePosition()
        {
            // 別スレッドから呼び出された場合の考慮.
            this.UIInvoke(() =>
            {
                for (var ii = 0; ii < this.pBoxList.Count; ii++)
                {
                    var pbox = this.pBoxList[ii];
                    var x = this.BaseX + (ii * this.Size.Height);
                    pbox.Location = new Point(x, 0);
                }
            });
        }
    }
}
