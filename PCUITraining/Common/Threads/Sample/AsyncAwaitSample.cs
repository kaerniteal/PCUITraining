using Common.Extentions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Threads.Sample
{
    public static class AsyncAwaitSample
    {
        /// <summary>
        /// Async Awaitを使用した非同期処理サンプル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Sample(object sender, EventArgs e)
        {
            Console.WriteLine("Clic begin");

            // 非同期処理を含む処理.
            AsyncRapper();

            // ここは AsyncRapper の中の非同期処理を待たずに処理される.
            Console.WriteLine("Clic end");
        }

        /// <summary>
        /// 非同期を含む処理(UIのコールバック自体がこの処理に該当するのがよくあるパターン。asyncを付ける必要がある).
        /// </summary>
        public static async void AsyncRapper()
        {
            Console.WriteLine("AsyncRapper begin");

            var res = await Task.Run(() => HavyFunc(3000));

            // ここは HavyFunc 実行後に処理される.
            Console.WriteLine("AsyncRapper end result[{0}]sec wait".Fmt(res));
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
