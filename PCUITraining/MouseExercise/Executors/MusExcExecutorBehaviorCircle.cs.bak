using Common.Extentions;
using MouseExercise.MusExcSet;
using System;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc挙動演算円運動クラス.
    /// </summary>
    public class MusExcExecutorBehaviorCircle : MusExcExecutorBehaviorBase
    {
        /// <summary>
        /// 挙動を加味した表示位置算出処理.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        public override void SetViewPoint(MusExcSharedDataUnitState unitState)
        {
            // 時計回り.
            var nextBehavior = BEHAVIOR_POS.UP;
            switch(unitState.CurrentBehavior)
            {
                case BEHAVIOR_POS.UP:
                    nextBehavior = BEHAVIOR_POS.RIGHT_UP;
                    break;

                case BEHAVIOR_POS.RIGHT_UP:
                    nextBehavior = BEHAVIOR_POS.RIGHT;
                    break;

                case BEHAVIOR_POS.RIGHT:
                    nextBehavior = BEHAVIOR_POS.RIGHT_DOWN;
                    break;

                case BEHAVIOR_POS.RIGHT_DOWN:
                    nextBehavior = BEHAVIOR_POS.DOWN;
                    break;

                case BEHAVIOR_POS.DOWN:
                    nextBehavior = BEHAVIOR_POS.LEFT_DOWN;
                    break;

                case BEHAVIOR_POS.LEFT_DOWN:
                    nextBehavior = BEHAVIOR_POS.LEFT;
                    break;

                case BEHAVIOR_POS.LEFT:
                    nextBehavior = BEHAVIOR_POS.LEFT_UP;
                    break;

                case BEHAVIOR_POS.LEFT_UP:
                    nextBehavior = BEHAVIOR_POS.UP;
                    break;
            }

            this.SetBehaviorPos(unitState, nextBehavior);
        }
    }
}
