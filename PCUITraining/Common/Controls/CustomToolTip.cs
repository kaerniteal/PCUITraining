using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Common.Controls
{
    /// <summary>
    /// カスタムツールチップ.
    /// </summary>

    public class CustomToolTip : ToolTip
    {
        /// <summary>
        /// フォント.
        /// </summary>
        public Font CustomFont { get; set; }

        /// <summary>
        /// 背景色.
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// テキスト色.
        /// </summary>
        public Color FontColor { get; set; }

        /// <summary>
        /// ボーダーの有無.
        /// </summary>
        public bool NeedBorder { get; set; }

        /// <summary>
        /// マージン.
        /// </summary>
        public int Margin { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public CustomToolTip() : base()
        {
            this.Init();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cont">IContainer</param>
        public CustomToolTip(IContainer cont) : base(cont)
        {
            this.Init();
        }

        /// <summary>
        /// 初期化.
        /// </summary>
        private void Init()
        {
            this.CustomFont = SystemFonts.CaptionFont;
            this.BackgroundColor = SystemColors.Control;
            this.FontColor = SystemColors.ActiveCaptionText;
            this.NeedBorder = true;
            this.Margin = 5;

            this.OwnerDraw = true;
            this.Popup += CustomToolTip_Popup;
            this.Draw += CustomToolTip_Draw;
        }

        /// <summary>
        /// Popupイベントハンドラ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomToolTip_Popup(object sender, PopupEventArgs e)
        {
            using (var font = (Font)this.CustomFont.Clone())
            {
                var fitSize = TextRenderer.MeasureText(this.GetToolTip(e.AssociatedControl), font);
                var margin = this.Margin * 2;
                e.ToolTipSize = new Size(fitSize.Width + margin, fitSize.Height + margin);
            }
        }

        /// <summary>
        /// Drowイベントハンドラ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            using (var brush = new SolidBrush(this.BackgroundColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            if (this.NeedBorder)
            {
                e.DrawBorder();
            }

            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                sf.FormatFlags = StringFormatFlags.NoWrap;

                using (var font = (Font)this.CustomFont.Clone())
                {
                    using (var brush = new SolidBrush(this.FontColor))
                    {
                        e.Graphics.DrawString(
                            e.ToolTipText,
                            font,
                            brush,
                            e.Bounds,
                            sf);
                    }
                }
            }
        }
    }
}
