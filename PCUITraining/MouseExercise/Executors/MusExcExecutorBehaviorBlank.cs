using MouseExercise.MusExcSet;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc挙動演算ブランククラス.
    /// </summary>
    public class MusExcExecutorBehaviorBlank : MusExcExecutorBehaviorBase
    {
        /// <summary>
        /// 挙動を加味した表示位置算出処理.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        public override void SetViewPoint(MusExcSharedDataUnitState unitState)
        {
            // 演算ナシ.
            unitState.ViewPoint = unitState.MovingPoint;
        }
    }
}
