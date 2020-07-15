using Common.Threads;
using System.Drawing;
using System.Windows.Forms;

namespace PCUITCommon.Views
{
    /// <summary>
    /// Waitダイアログ
    /// </summary>
    public partial class FormWait : Form
    {
        /// <summary>
        /// 表示時間(ms)
        /// </summary>
        private int ShowTime { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="showtime">表示時間(ms)</param>
        /// <param name="imagePath">表示画像</param>
        public FormWait(int showtime, string imagePath)
        {
            InitializeComponent();

            this.ShowTime = showtime;

            var image = new Bitmap(imagePath);
            this.pBox.Image = image;
        }

        /// <summary>
        /// フォームロード.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormWait_Load(object sender, System.EventArgs e)
        {
            // 指定秒後に閉じる.
            AnimationTimer.Animate(this.ShowTime, (frame, frequency) =>
            {
                if (!this.Visible || this.IsDisposed)
                {
                    return false;
                }

                if (frame == frequency)
                {
                    this.Close();
                }

                return true;
            });
        }
    }
}
