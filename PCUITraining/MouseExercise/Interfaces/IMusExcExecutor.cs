using MouseExercise.MusExcSet;

namespace MouseExercise.Interfaces
{
    /// <summary>
    /// 実行インタフェース
    /// </summary>
    public interface IMusExcExecutor
    {
        /// <summary>
        /// 処理開始.
        /// </summary>
        /// <param name="sharedData">共有データ</param>
        void Start(MusExcSharedData sharedData);

        /// <summary>
        /// 入力されたクリック
        /// </summary>
        /// <param name="unitIndex">ユニットIndex</param>
        void InputClick(int unitIndex);

        /// <summary>
        /// 処理停止.
        /// </summary>
        void Stop();
    }
}
