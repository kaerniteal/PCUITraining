using System;
using System.Windows.Forms;

namespace Common.Thread
{
    /// <summary>
    /// コントロールアニメーションクラス.
    /// </summary>
    public static class AnimationTimer
    {
        /// <summary>
        /// フォームのタイマが扱える下限のインターバル.
        /// </summary>
        public const int DEFAULT_INTERVAL = 55;


        /// <summary>
        /// 1 フレームの時間とフレーム数を指定してアニメーション機能を提供します。
        /// </summary>
        /// <param name="interval">1 フレームの時間をミリ秒単位で指定します。実質の下限は55msです</param>
        /// <param name="frequency">
        /// frequency はコールバックが呼ばれる回数から 1 を引いたものです。例えば frequency が 10 の時には 11 回呼ばれます。
        /// </param>
        /// <param name="callback">
        /// bool callback(int frame, int frequency) の形でコールバックを指定します。
        /// frame は 0 から frequency の値まで 1 ずつ増加します。
        /// frequency は引数で指定した値そのものです。
        /// </param>
        public static void Animate(int interval, int frequency, Func<int, int, bool> callback)
        {
            var timer = new Timer();
            timer.Interval = interval;

            int frame = 0;
            timer.Tick += (sender, e) =>
            {
                var result = callback(frame, frequency);
                if (!result || frequency <= frame)
                {
                    timer.Stop();
                }

                frame++;
            };

            timer.Start();
        }

        /// <summary>
        /// 持続時間を指定してアニメーション機能を提供します。
        /// </summary>
        /// <param name="duration">持続時間をミリ秒単位で指定します。</param>
        /// <param name="callback">
        /// bool callback(int frame, int frequency) の形でコールバックを指定します。
        /// frame は 0 から frequency の値まで 1 ずつ増加します。
        /// frequency はコールバックが呼ばれる回数から 1 を引いたものです。例えば frequency が 10 の時には 11 回呼ばれます。
        /// </param>
        public static void Animate(int duration, Func<int, int, bool> callback)
        {
            // 安全装置.
            if (duration < DEFAULT_INTERVAL)
            {
                duration = DEFAULT_INTERVAL;
            }

            // 呼び出し回数(実際にはfrequency+1回呼ばれる).
            var frequency = duration / DEFAULT_INTERVAL;

            Animate(DEFAULT_INTERVAL, frequency, callback);
        }
    }
}
