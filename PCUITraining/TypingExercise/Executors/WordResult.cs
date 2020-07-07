using PCUITCommon.Datas;

namespace TypingExercise.Executors
{
    /// <summary>
    /// 単語毎の入力結果.
    /// </summary>
    public class WordResult
    {
        /// <summary>
        /// 入力対象文字列.
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// 計測タイム.
        /// </summary>
        public long MeasuredTime { get; set; }

        /// <summary>
        /// ミスタイプ回数.
        /// </summary>
        public int MissTypeCount { get; set; }

        /// <summary>
        /// 連続ノーミスカウント.
        /// </summary>
        public int ConsecutiveNoMissCount { get; set; }

        /// <summary>
        /// イメージストア.
        /// </summary>
        public ImageStore ImageStore { get; set; }

        /// <summary>
        /// マスタボールが使われたかどうか.
        /// </summary>
        public bool UseMasterBoll { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="word">文字列</param>
        public WordResult(string word)
        {
            this.Word = word;
            this.MeasuredTime = 0;
            this.MissTypeCount = 0;
            this.ConsecutiveNoMissCount = 0;
            this.ImageStore = null;
            this.UseMasterBoll = false;
        }
    }
}
