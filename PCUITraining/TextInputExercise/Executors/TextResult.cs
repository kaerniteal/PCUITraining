using PCUITCommon.Datas;

namespace TextInputExercise.Executors
{
    /// <summary>
    /// 単語毎の入力結果.
    /// </summary>
    public class TextResult
    {
        /// <summary>
        /// 入力対象文字列.
        /// </summary>
        public string Text { get; set; }

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
        /// コンストラクタ.
        /// </summary>
        /// <param name="text">文字列</param>
        public TextResult(string text)
        {
            this.Text = text;
            this.MeasuredTime = 0;
            this.MissTypeCount = 0;
            this.ConsecutiveNoMissCount = 0;
        }
    }
}
