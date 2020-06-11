using Common.Extentions;
using System;

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
        /// ランダムな数値を返します.
        /// </summary>
        /// <param name="max">最大</param>
        /// <returns>ランダムな数値</returns>
        public static int Next(int max)
        {
            InitRandom();

            return Random.Next(max);
        }

        /// <summary>
        /// ランダムな数値を返します.
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

            long unixTime = DateTime.Now.GetUnixTime();
            var seed = (int)(unixTime % int.MaxValue);
            Random = new Random(seed);
        }
    }
}
