using System;

namespace Common.Extentions
{
    /// <summary>
    /// DateTime型拡張メソッドを定義します.
    /// </summary>
    public static class DateTimeExtentions
    {
        /// <summary>
        /// UNIXエポックを表すDateTimeオブジェクト 
        /// </summary>
        private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);


        /// <summary>
        /// 通算秒を得る. 
        /// </summary>
        /// <param name="self">自身</param>
        public static long GetUnixTime(this DateTime self)
        {
            // UTC時間に変換
            var utcTime = self.ToUniversalTime();

            // UNIXエポックからの経過時間を取得
            var span = utcTime - UNIX_EPOCH;

            // 経過秒数に変換
            return (long)span.TotalSeconds;
        }

        /// <summary> 
        /// 積算秒(JST)を取得する. 
        /// </summary> 
        /// <returns>積算秒(JST)</returns>
        public static long GetUnixTimeJST(this DateTime self)
        {
            // JSTでUNIXエポックからの経過を取得して秒に変換.
            return (long)(self - UNIX_EPOCH).TotalSeconds;
        }

        /// <summary> 
        /// 正分を取得する. 
        /// </summary> 
        /// <returns>正分に整えたオブジェクト</returns>
        public static DateTime GetOnMinute(this DateTime self)
        {
            // 正分に整えたオブジェクト.
            return self.AddSeconds(-self.Second);
        }

        /// <summary> 
        /// 正時を取得する. 
        /// </summary> 
        /// <returns>正時に整えたオブジェクト</returns>
        public static DateTime GetOnHour(this DateTime self)
        {
            // 正時に整えたオブジェクト.
            return self.AddSeconds(-(self.Second + (self.Minute * 60)));
        }
    }
}
