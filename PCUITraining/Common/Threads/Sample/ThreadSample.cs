using Common.Extentions;
using System;
using System.Threading;

namespace Common.Threads.Sample
{
    /// <summary>
    /// Threadを使用した非同期処理サンプル
    /// </summary>
    public static class ThreadSample
    {
        /// <summary>
        /// 結果を格納.
        /// </summary>
        private static int result = 0;


        /// <summary>
        /// 非同期処理を含む処理.
        /// </summary>
        public static void Sample()
        {
            Console.WriteLine("Sample begin");

            result = 0;
            var waitTime = 1000;

            // 引数無しで非同期処理を呼び出す.
            var thread = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine("HavyFunc begin");
                Thread.Sleep(waitTime);
                Console.WriteLine("HavyFunc end");

                result = waitTime / 1000;
            }));

            thread.Start();

            // この処理はブロックされずにthread.Start直後に実行される.
            // resultには初期化されたときのまま 0 が入っている.
            Console.WriteLine("Sample middle result[{0}]".Fmt(result));

            // ここでブロックされる.
            thread.Join();

            // ブロック後に呼ばれる.
            // resultにはThread処理の最後の結果が入っている.
            Console.WriteLine("Sample end result[{0}]sec wait".Fmt(result));
        }

        /// <summary>
        /// 非同期処理を含む処理.
        /// </summary>
        public static void SampleArg()
        {
            Console.WriteLine("Sample begin");

            result = 0;

            // 引数付きで非同期処理を呼び出す.
            var thread = new Thread(new ParameterizedThreadStart((param) =>
           {
               var val = (int)param;

               Console.WriteLine("HavyFunc begin");
               Thread.Sleep(val);
               Console.WriteLine("HavyFunc end");

               result = val / 1000;
           }));

            thread.Start(1000);

            // この処理はブロックされずにthread.Start直後に実行される.
            // resultには初期化されたときのまま 0 が入っている.
            Console.WriteLine("Sample middle result[{0}]".Fmt(result));

            // ここでブロックされる.
            thread.Join();

            // ブロック後に呼ばれる.
            // resultにはThread処理の最後の結果が入っている.
            Console.WriteLine("Sample end result[{0}]sec wait".Fmt(result));
        }
    }
}
