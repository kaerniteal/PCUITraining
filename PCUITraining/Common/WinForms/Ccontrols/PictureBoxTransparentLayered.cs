using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Common.WinForms.Ccontrols
{
    /// <summary>
    /// 透過画像を重ねられるPictureBox
    /// </summary>
    /// <remarks>
    /// 普通のPictureBoxに透過画像を入れて複数重ねると、
    /// 透過部分は背景(通常はフォーム)の色で塗りつぶされてしまう.
    /// 透過部分にさらに下位の透過画像を重ねて描画させるためのコンポーネント.
    /// </remarks>
    public class PictureBoxTransparentLayered : PictureBox
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PictureBoxTransparentLayered()
        {
            this.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 描画イベント.
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // 最も下位の背景を描画する.
            base.OnPaintBackground(pevent);

            try
            {
                // 親コントロールと自身との間のコントロールを、親方向から描画.
                for (var ii = this.Parent.Controls.Count - 1; 0 <= ii; ii--)
                {
                    var ctrl = this.Parent.Controls[ii];

                    // 自身まできたらそれ以上の描画は不要.
                    if (this.Equals(ctrl))
                    {
                        break;
                    }

                    // 重なり合っていないコントロールは考慮不要.
                    if (!this.Bounds.IntersectsWith(ctrl.Bounds))
                    {
                        continue;
                    }

                    // 描画する.
                    this.DrawBackControl(ctrl, pevent);
                }
            }
            catch (Exception)
            {
                // 処理なし.
            }
        }

        /// <summary>
        /// コントロールを背景として描画する.
        /// </summary>
        /// <param name="ctrl">描画対象コントロール</param>
        /// <param name="pevent">描画インベントパラメータ</param>
        private void DrawBackControl(Control ctrl, PaintEventArgs pevent)
        {
            // 重なりあっている領域を取得
            var layeredBase = Rectangle.Intersect(this.Bounds, ctrl.Bounds);

            // コントロールの重なり合っている領域を算出.
            var layerd = new Rectangle(
                layeredBase.X - ctrl.Bounds.X,
                layeredBase.Y - ctrl.Bounds.Y,
                layeredBase.Width,
                layeredBase.Height);

            // 自身の重なり合っている領域の開始点を取得.
            var thisX = layeredBase.X - this.Bounds.X;
            var thisY = layeredBase.Y - this.Bounds.Y;

            // 空のビットマップを用意.
            using (var bmp = new Bitmap(ctrl.Width, ctrl.Height, PixelFormat.Format32bppArgb))
            {
                // コントロールをキャプチャ
                ctrl.DrawToBitmap(bmp, new Rectangle(0, 0, ctrl.Width, ctrl.Height));

                // 自身の重なっている部分にキャプチャを描画.
                pevent.Graphics.DrawImage(bmp, thisX, thisY, layerd, GraphicsUnit.Pixel);
            }
        }
    }
}
