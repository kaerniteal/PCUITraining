using MouseExercise.MusExcSet;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc挙動演算左右揺れクラス.
    /// </summary>
    public class MusExcExecutorBehaviorSwayLR : MusExcExecutorBehaviorBase
    {
        /// <summary>
        /// 挙動を加味した表示位置算出処理.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        public override void SetViewPoint(MusExcSharedDataUnitState unitState)
        {
            var nextBehavior = BEHAVIOR_POS.LEFT;
            if (nextBehavior == unitState.CurrentBehavior)
            {
                nextBehavior = BEHAVIOR_POS.RIGHT;
            }

            this.SetBehaviorPos(unitState, nextBehavior);
        }
    }
}
