using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace Common.Sort
{
    /// <summary>
    /// 自然ソート比較クラス.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class NaturalComparer<T> : IComparer<T>
    {
        /// <summary>
        /// 文字列を返す処理.
        /// </summary>
        private Func<T, string> FuncGetString { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="funcGetString">比較対象の文字列を取得するデリゲート</param>
        public NaturalComparer(Func<T, string> funcGetString)
        {
            this.FuncGetString = funcGetString;
        }

        /// <summary>
        /// IComparerの実装.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Compare(T a, T b)
        {
            return SafeNativeMethods.StrCmpLogicalW(FuncGetString(a), FuncGetString(b));
        }
    }


    /// <summary>
    /// ネイティブメソッド呼び出し用クラス.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        public static extern int StrCmpLogicalW(string psz1, string psz2);
    }
}
