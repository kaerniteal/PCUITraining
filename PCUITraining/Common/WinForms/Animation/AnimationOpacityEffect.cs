using Common.Threads;
using System.Windows.Forms;

namespace Common.WinForms.Animation
{
    /// <summary>
    /// コントロールアニメーション(透明⇒不透明)クラス.
    /// </summary>
    public class AnimationOpacityEffect
    {
        /// <summary>
        /// 対象フォーム.
        /// </summary>
        private Form Control { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="form">描画対象フォーム</param>
        public AnimationOpacityEffect(Form form)
        {
            this.Control = form;
        }

        /// <summary>
        /// フェードイン.
        /// </summary>
        /// <param name="duration">アニメーション時間(ms)</param>
        public void FadeIn(int duration)
        {
            this.Control.Opacity = 0;

            // 透明 ⇒ 不透明に変える.
            AnimationTimer.Animate(duration, (frame, frequency) =>
            {
                if (!this.Control.Visible || this.Control.IsDisposed)
                {
                    return false;
                }

                this.Control.Opacity = (double)frame / frequency;

                return true;
            });
        }
    }
}
