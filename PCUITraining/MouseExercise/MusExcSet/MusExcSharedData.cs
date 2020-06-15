namespace MouseExercise.MusExcSet
{
    /// <summary>
    /// MusExc実行時のルートデータ.
    /// </summary>
    public class MusExcSharedData
    {
        /// <summary>
        /// 処理継続フラグ.
        /// </summary>
        public bool Continue { get; set; }

        /// <summary>
        /// 更新中フラグ.
        /// </summary>
        public bool Updating { get; set; }

        /// <summary>
        /// 処理カウンタ
        /// </summary>
        public int Counter { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcSharedData()
        {
            this.Continue = true;
            this.Updating = false;
            this.Counter = 0;
        }
    }
}
