using Common.Extentions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Threads.Sample
{
    /// <summary>
    /// Async Awaitを使用した非同期処理サンプル
    /// </summary>
    public static class AsyncAwaitSample
    {
        /// <summary>
        /// 非同期処理を呼ぶ処理.
        /// </summary>
        public static void Sample()
        {
            // この処理だけ見れば同期的に進む.
            Console.WriteLine("Sample begin");

            // 非同期処理を含む処理.
            AsyncFunc();

            // ここは AsyncFunc 呼び出し後、続けて処理される(非同期処理を待たない).
            Console.WriteLine("Sample end");
        }

        /// <summary>
        /// 非同期処理を含む処理.
        /// </summary>
        /// <remarks>
        /// UIのコールバック自体がこの処理に該当するのがよくあるパターン。
        /// asyncを付ける必要がある。
        /// 非同期処理の後処理もこの中に記載できる。
        /// </remarks>
        public static async void AsyncFunc()
        {
            Console.WriteLine("AsyncFunc begin");

            var res = await Task.Run(() => HavyFunc(3000));

            // ここは HavyFunc 実行後に処理される.
            Console.WriteLine("AsyncFunc end result[{0}]sec wait".Fmt(res));
        }

        /// <summary>
        /// 非同期処理本体.
        /// </summary>
        /// <param name="waitTime"></param>
        private static int HavyFunc(int waitTime)
        {
            Console.WriteLine("HavyFunc begin");
            Thread.Sleep(waitTime);
            Console.WriteLine("HavyFunc end");

            return waitTime / 1000;
        }
    }
}
