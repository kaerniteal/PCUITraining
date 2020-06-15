using MouseExercise.Interfaces;
using MouseExercise.MusExcSet;
using System;
using System.Threading;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc実行クラス.
    /// </summary>
    public class MusExcExecutor
    {
        /// <summary>
        /// 処理開始.
        /// </summary>
        /// <param name="viewer"></param>
        /// <returns></returns>
        public MusExcSharedData Start(IMusExcViewer viewer)
        {
            var data = new MusExcSharedData();

            // 実行パラメータを生成.
            var param = new Tuple<IMusExcViewer, MusExcSharedData>(
                viewer,
                data);

            // 読み込み処理を別スレッドで実行.
            var thread = new Thread(new ParameterizedThreadStart(MusExcExecMain));
            thread.Start(param);

            return data;
        }

        /// <summary>
        /// 別スレッドメイン処理.
        /// </summary>
        /// <param name="paramater">パラメータ</param>
        private static void MusExcExecMain(object paramater)
        {
            // パラメータを取得.
            var param = paramater as Tuple<IMusExcViewer, MusExcSharedData>;
            if (null == param)
            {
                return;
            }

            var viewer = param.Item1;
            var data = param.Item2;

            // メインループ.
            var wait = 100;
            for (int ii =0; ii < int.MaxValue && data.Continue; ii++)
            {
                data.Counter = ii;



                if (!data.Updating)
                {
                    viewer.ViewUpdate();
                }
                else
                {
                    // 描画更新中.
                    Console.WriteLine("not update >> " + ii);
                }

                Thread.Sleep(wait);
            }
        }
    }
}
