using MouseExercise.MusExcSet;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc挙動演算上下揺れクラス.
    /// </summary>
    public class MusExcExecutorBehaviorSwayUD : MusExcExecutorBehaviorBase
    {
        /// <summary>
        /// 挙動を加味した表示位置算出処理.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        public override void SetViewPoint(MusExcSharedDataUnitState unitState)
        {
            var nextBehavior = BEHAVIOR_POS.UP;
            if (nextBehavior == unitState.CurrentBehavior)
            {
                nextBehavior = BEHAVIOR_POS.DOWN;
            }

            this.SetBehaviorPos(unitState, nextBehavior);
        }
    }
}
