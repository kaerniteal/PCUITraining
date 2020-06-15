using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Common.Extentions
{
    /// <summary>
    /// コントロール拡張メソッドを定義します.
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Invokeのデリゲート省略.
        /// </summary>
        /// <param name="control">自分自身</param>
        /// <param name="act">アクション</param>
        public static void UIInvoke(this Control control, Action act)
        {
            if (control.IsHandleCreated)
            {
                control.BeginInvoke((MethodInvoker)(() => act()));
            }
        }

        /// <summary>
        /// 描画更新ネイティブメソッドの定義.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0x000B;

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

        /// <summary>
        /// チェックボックスを更新イベント付きで初期化.
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <param name="value">新しい値</param>
        public static void Init(this CheckBox self, bool value)
        {
            // 値が同じ場合値の変更イベントが走らない為、一度逆の値に変更する.
            if (self.Checked == value)
            {
                self.Checked = !value;
            }

            // 値をセット.
            self.Checked = value;
        }
    }
}