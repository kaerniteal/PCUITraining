using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Common.Extentions
{
    /// <summary>
    /// コントロール拡張メソッド(WinApi)を定義します.
    /// </summary>
    public static class ControlWinApiExtensions
    {
        private const int WM_SETREDRAW = 0x000B;


        /// <summary>
        /// ネイティブメソッドの定義.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);


        /// <summary>
        /// コントロールの再描画を停止させる
        /// </summary>
        /// <param name="self">自分自身</param>
        public static void BeginControlUpdate(this Control self)
        {
            SendMessage(new HandleRef(self, self.Handle), WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// コントロールの再描画を再開させる
        /// </summary>
        /// <param name="self">自分自身</param>
        public static void EndControlUpdate(this Control self)
        {
            SendMessage(new HandleRef(self, self.Handle), WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
            self.Refresh();
        }
    }
}