using Common.Extentions;
using System;
using System.Collections.Generic;

namespace Common.Utilities
{
    /// <summary>
    /// ランダムクラス.
    /// </summary>
    public static class UtilRandom
    {
        /// <summary>
        /// ランダム生成クラス.
        /// </summary>
        private static Random Random { get; set; }

        /// <summary>
        /// [0 <= value < max]でランダムな数値を返します.
        /// </summary>
        /// <param name="max">最大</param>
        /// <returns>ランダムな数値</returns>
        public static int Next(int max)
        {
            InitRandom();

            return Random.Next(max);
        }

        /// <summary>
        /// [min <= value < max]でランダムな数値を返します.
        /// </summary>
        /// <param name="min">最小</param>
        /// <param name="max">最大</param>
        /// <returns>ランダムな数値</returns>
        public static int Next(int min, int max)
        {
            InitRandom();

            return Random.Next(min, max);
        }

        /// <summary>
        /// 初期化.
        /// </summary>
        private static void InitRandom()
        {
            if (null != Random)
            {
                return;
            }

            var unixTime = DateTime.Now.GetUnixTime();
            var seed = (int)(unixTime % int.MaxValue);
            Random = new Random(seed);
        }

        /// <summary>
        /// 1/2 の確率でTRUEを返す.
        /// </summary>
        /// <returns>true/false 50%/50%</returns>
        public static bool Half()
        {
            return 0 == Next(2);
        }

        /// <summary>
        /// リストからランダムで要素を取得する.
        /// </summary>
        /// <param name="self">自身</param>
        /// <returns>ランダムで取得する要素</returns>
        public static T GetRandom<T>(this List<T> self)
        {
            var index = Next(self.Count);
            return self[index];
        }

        /// <summary>
        /// 配列からランダムで要素を取得する.
        /// </summary>
        /// <param name="self">自身</param>
        /// <returns>ランダムで取得する要素</returns>
        public static T GetRandom<T>(this T[] self)
        {
            var index = Next(self.Length);
            return self[index];
        }
    }
}
