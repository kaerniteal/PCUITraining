using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Common.WinForms.Ccontrols
{
    /// <summary>
    /// メッセージ表示機能の付いたプログレスバーコントロール.
    /// </summary>
    public class ProgressBarWithMessage : ProgressBar
    {
        /// <summary>
        /// メッセージモード.
        /// </summary>
        public enum MESSAGE_MODE
        {
            NON,
            PERCENT,
            MESSAGE,
        }

        /// <summary>
        /// 描画イベント.
        /// </summary>
        private const int WM_PAINT = 0x000F;

        /// <summary>
        /// メッセージモード.
        /// </summary>
        public MESSAGE_MODE MessageMode { get; set; } = MESSAGE_MODE.NON;

        /// <summary>
        /// メッセージ.
        /// </summary>
        private string Message { get; set; } = string.Empty;

        /// <summary>
        /// メッセージセット.
        /// </summary>
        /// <param name="message"></param>
        public void SetMessage(string message)
        {
            this.Message = message;

            // 再描画.
            this.Refresh();
        }

        /// <summary>
        /// メッセージ処理オーバーライド.
        /// </summary>
        /// <param name="winMessage">Windowsメッセージ</param>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message winMessage)
        {
            // 元処理を呼び出す.
            base.WndProc(ref winMessage);

            // 描画更新の場合は.
            if (winMessage.Msg == WM_PAINT)
            {
                // 表示する文字列を決定する
                var displayText = string.Empty;
                switch (this.MessageMode)
                {
                    case MESSAGE_MODE.PERCENT:
                        var percent = (double)(this.Value - this.Minimum) / (double)(this.Maximum - this.Minimum);
                        displayText = $"{(int)(percent * 100.0)}%";
                        break;

                    case MESSAGE_MODE.MESSAGE:
                        displayText = this.Message;
                        break;

                    default:
                        displayText = string.Empty;
                        break;
                }

                // 文字列を描画する
                var tff = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine;
                using (var g = this.CreateGraphics())
                {
                    TextRenderer.DrawText(g, displayText, this.Font, this.ClientRectangle, SystemColors.ControlText, tff);
                }
            }
        }
    }
}
