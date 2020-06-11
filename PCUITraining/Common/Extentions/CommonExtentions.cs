using System;
using System.Windows.Forms;

namespace Common.Extentions
{
    /// <summary>
    /// ユーティリティ拡張メソッドを定義します.
    /// </summary>
    public static class CommonExtentions
    {
        /// <summary>
        /// 例外をメッセージボックスで表示する. 
        /// </summary>
        /// <param name="self">自身</param>
        public static void ShowMessageBox(this Exception self)
        {
            MessageBox.Show("{0}\n\n{1}\n{2}".Fmt(self.Message, self, self.StackTrace));
        }

        /// <summary>
        /// 例外をメッセージボックスで表示する. 
        /// </summary>
        /// <param name="self">自身</param>
        /// <param name="message">メッセージ</param>
        public static void ShowMessageBox(this Exception self, string message)
        {
            MessageBox.Show("{0}\n{1}".Fmt(message, self.Message));
        }

        /// <summary>
        /// int値をEnum値へ変換する.
        /// </summary>
        /// <typeparam name="TEnum">Enum</typeparam>
        /// <param name="self">自身</param>
        /// <returns>Enum</returns>
        public static TEnum ToEnum<TEnum>(this int self) where TEnum : struct
        {
            //値が定義されていれば
            if (Enum.IsDefined(typeof(TEnum), self))
            {
                // いったんobjectにキャストしてからENUMにキャストして返す.
                return (TEnum)(object)self;
            }
            else
            {
                //定義されてなければ例外を投げる
                throw new ArgumentException();
            }
        }
    }
}
