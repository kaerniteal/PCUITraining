namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    /// <summary>
    /// 昆虫採集セットゲームデータレコード.
    /// </summary>
    public class InsectCollectingSetGameDataRecord
    {
        /// <summary>
        /// 名前.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 画像ファイルパス.
        /// </summary>
        public string ImageFilePath { get; set; }

        /// <summary>
        /// 捕獲数.
        /// </summary>
        public int CaptureCount { get; set; } 


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public InsectCollectingSetGameDataRecord()
        {
            this.Name = string.Empty;
            this.ImageFilePath = string.Empty;
            this.CaptureCount = 0;
        }
    }
}
