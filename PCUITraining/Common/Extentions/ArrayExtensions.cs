using System.Collections.Generic;

namespace Common.Extentions
{
    /// <summary>
    /// 配列を扱うための拡張クラス.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// リストの左部を取得する(< Index). 
        /// </summary>
        /// <param name="self">自身</param>
        /// <param name="index">指定したIndex この値自体の要素は含まない</param>
        public static List<T> Left<T>(this List<T> self, int index)
        {
            if (index < 0 && self.Count <= index)
            {
                return self;
            }

            return self.GetRange(0, index);
        }

        /// <summary>
        /// リストの右部を取得する(Index <=). 
        /// </summary>
        /// <param name="self">自身</param>
        /// <param name="index">指定したIndex このIndex自体の要素を含む</param>
        public static List<T> Right<T>(this List<T> self, int index)
        {
            if (index < 0 && self.Count <= index)
            {
                return self;
            }

            return self.GetRange(index, self.Count - index);
        }
    }
}
