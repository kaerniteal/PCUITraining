using Common.Threads;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Common.WinForms.Animation
{
    /// <summary>
    /// コントロールアニメーション(円描画)クラス.
    /// </summary>
    public class AnimationCircleEffect
    {
        /// <summary>
        /// 対象コントロール.
        /// </summary>
        private Control Control { get; set; }

        /// <summary>
        /// 半径.
        /// </summary>
        private int Radius { get; set; }

        /// <summary>
        /// 描画幅.
        /// </summary>
        private int Ox { get; set; }

        /// <summary>
        /// 描画高.
        /// </summary>
        private int Oy { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="control">描画対象コントロール</param>
        public AnimationCircleEffect(Control control)
        {
            this.Control = control;

            this.Radius = (int)(Math.Sqrt(this.Control.Width * this.Control.Width + this.Control.Height * this.Control.Height) / 2);
            this.Ox = this.Control.Width / 2;
            this.Oy = this.Control.Height / 2;

            this.Control.Region = new Region(new GraphicsPath());
        }

        /// <summary>
        /// フェードイン.
        /// </summary>
        /// <param name="duration">アニメーション時間(ms)</param>
        /// <param name="action">フェードイン後に実施するアクション</param>
        public void FadeIn(int duration, Action action = null)
        {
            // 円のエフェクトでフォームを描画する.
            AnimationTimer.Animate(duration, (frame, frequency) =>
            {
                if (!this.Control.Visible || this.Control.IsDisposed)
                {
                    return false;
                }

                var r = this.Radius * frame / frequency;

                using (var gp = new GraphicsPath())
                {
                    gp.AddEllipse(new Rectangle(this.Ox - r, this.Oy - r, r * 2, r * 2));
                    this.Control.Region = new Region(gp);
                }

                if (frame == frequency)
                {
                    this.Control.Region = null;
                    if (null != action)
                    {
                        action();
                    }
                }

                return true;
            });
        }

        /// <summary>
        /// フェードアウト.
        /// </summary>
        /// <param name="duration">アニメーション時間(ms)</param>
        /// <param name="action">フェードアウト後に実施するアクション</param>
        public void FadeOut(int duration, Action action = null)
        {
            // 円のエフェクトでフォームを描画する.
            AnimationTimer.Animate(duration, (frame, frequency) =>
            {
                if (this.Control.IsDisposed)
                {
                    return false;
                }

                int r = (int)(this.Radius * ((frequency - (float)frame) / frequency));

                using (var gp = new GraphicsPath())
                {
                    gp.AddEllipse(new Rectangle(this.Ox - r, this.Oy - r, r * 2, r * 2));
                    this.Control.Region = new Region(gp);
                }

                if (frame == frequency)
                {
                    if (null != action)
                    {
                        action();
                    }
                }

                return true;
            });
        }
    }
}
