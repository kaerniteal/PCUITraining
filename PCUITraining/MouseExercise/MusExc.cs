using MouseExercise.Configs;

namespace MouseExercise
{
    /// <summary>
    /// マウスアプリ－メインクラス.
    /// </summary>
    public class MusExc
    {
        /// <summary>
        /// 設定.
        /// </summary>
        public static MusExcConf Conf { get; set; }


        /// <summary>
        /// 初期化処理.
        /// </summary>
        /// <returns>成否</returns>
        public bool Init()
        {
            Conf = MusExcConf.Load();

            return true;
        }
    }
}
