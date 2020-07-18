using Common.Extentions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Threads.Sample
{
    /// <summary>
    /// Taskを使用した非同期処理サンプル
    /// </summary>
    public static class TaskSample
    {
        /// <summary>
        /// 非同期処理を含む処理.
        /// </summary>
        public static void Sample()
        {
            Console.WriteLine("Sample begin");

            var task = Task.Run(() => HavyFunc(3000));

            // この処理はブロックされずにTask.Run直後に実行される.
            Console.WriteLine("Sample middle");

            // ここでブロックされる.
            // Resultの参照にwaitが含まれている.
            // 戻り値を参照しないのであれば不要.
            var result = task.Result;

            // ブロック後に呼ばれる.
            Console.WriteLine("Sample end result[{0}]sec wait".Fmt(result));
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
