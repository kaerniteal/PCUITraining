using System;

namespace Common.Extentions
{
    /// <summary>
    /// 文字列拡張メソッドを定義します.
    /// </summary>
    public static class StringExtentions
    {
        /// <summary>
        /// string.Formatを行います。
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <param name="args">引数</param>
        /// <returns>整形済み文字列</returns>
        public static string Fmt(this string self, params object[] args)
        {
            return string.Format(self, args);
        }

        /// <summary>
        /// Nullか空文字かどうかを判定します。
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <returns>Nullまたは空文字の場合はTrue, それ以外はFalse</returns>
        public static bool IsEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        /// <summary>
        /// 指定された文字列に該当する箇所より左側を取得する.
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <param name="dst">切り出したい区切り文字列</param>
        /// <returns>dstを含まない、文字列の左部</returns>
        public static string Left(this string self, string dst)
        {
            var index = self.IndexOf(dst);
            if (0 <= index)
            {
                return self.Substring(0, index);
            }

            return self;
        }

        /// <summary>
        /// 指定された文字列に該当する箇所より右側を取得する.
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <param name="dst">切り出したい区切り文字列</param>
        /// <returns>dstを含まない、文字列の右部</returns>
        public static string Right(this string self, string dst)
        {
            var index = self.IndexOf(dst);
            if (0 <= index)
            {
                return self.Substring(index + dst.Length);
            }

            return self;
        }

        /// <summary>
        /// 数値文字列を数値へ変換する(変換不能な場合は0にする).
        /// </summary>
        /// <param name="self">変換元数値文字列</param>
        /// <returns>変換後の数値</returns>
        public static int ToInt(this string self)
        {
            var value = 0;
            if (!int.TryParse(self, out value))
            {
                return 0;
            }

            return value;
        }

        /// <summary>
        /// 数値文字列をEnumへ変換する.
        /// </summary>
        /// <typeparam name="TEnum">変換先のEnum型</typeparam>
        /// <param name="self">変換元数値文字列</param>
        /// <returns>変換後のEnum値</returns>
        public static TEnum ToEnum<TEnum>(this string self)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), self, true);
        }
    }
}
