namespace MouseExercise.MusExcSet
{
    /// <summary>
    /// 実行結果レコードクラス.
    /// </summary>
    public class MusExcSharedDataResultRecord
    {
        /// <summary>
        /// ユニット名
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// クリック数
        /// </summary>
        public int ClickedCount { get; set; }

        /// <summary>
        /// ユニット定義.
        /// </summary>
        public MusExcQuestionDefUnit DefUnit { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcSharedDataResultRecord()
        {
            this.UnitName = string.Empty;
            this.ClickedCount = 0;
            this.DefUnit = new MusExcQuestionDefUnit();
        }
    }
}
