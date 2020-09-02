using System;
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
                if (control.InvokeRequired)
                {
                    control.BeginInvoke((MethodInvoker)(() => act()));
                }
                else
                {
                    act();
                }
            }
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