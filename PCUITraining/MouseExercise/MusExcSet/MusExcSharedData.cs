using Common.Extentions;

namespace MouseExercise.MusExcSet
{
    /// <summary>
    /// MusExc実行時の共有データ.
    /// </summary>
    /// <remarks>書き込みはExecutor、読み取りはViewer</remarks>
    public class MusExcSharedData
    {
        /// <summary>
        /// 処理カウンタ
        /// </summary>
        public int Counter { get; set; }

        /// <summary>
        /// 残り時間(ms).
        /// </summary>
        public int Remaining { get; set; }

        /// <summary>
        /// ユニット状態リスト
        /// </summary>
        public MusExcSharedDataUnitState[] UnitStateList { get; set; }

        /// <summary>
        /// 実行結果.
        /// </summary>
        public MusExcSharedDataResult Result { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcSharedData()
        {
            this.Counter = 0;
            this.Remaining = 0;
            this.UnitStateList = new MusExcSharedDataUnitState[0];
            this.Result = new MusExcSharedDataResult();
        }

        /// <summary>
        /// 残り時間文字列.
        /// </summary>
        /// <returns></returns>
        public string GetRemaining()
        {
            return @"{0:D2}.{1:D3}".Fmt(this.Remaining / 1000, this.Remaining % 1000);
        }
    }
}
