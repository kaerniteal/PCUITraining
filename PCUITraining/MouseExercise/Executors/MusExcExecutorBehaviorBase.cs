using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc挙動演算基底クラス.
    /// </summary>
    public abstract class MusExcExecutorBehaviorBase
    {
        /// <summary>
        /// 挙動を加味した表示位置算出処理.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        public abstract void SetViewPoint(MusExcSharedDataUnitState unitState);


        /// <summary>
        /// 挙動演算クラスを取得する(ファクトリ).
        /// </summary>
        /// <param name="behavior">挙動</param>
        /// <returns>演算クラス</returns>
        public static MusExcExecutorBehaviorBase GetBehavior(BEHAVIOR behavior)
        {
            switch (behavior)
            {
                case BEHAVIOR.NON:      // なし
                    return new MusExcExecutorBehaviorBlank();

                case BEHAVIOR.SWAY_LR:  // 左右揺れ
                    return new MusExcExecutorBehaviorSwayLR();

                case BEHAVIOR.SWAY_UD:  // 上下揺れ
                    return new MusExcExecutorBehaviorSwayUD();

                case BEHAVIOR.CIRCLE:   // 円運動
                    return new MusExcExecutorBehaviorCircle();

                default:
                    return new MusExcExecutorBehaviorBlank();
            }
        }

        /// <summary>
        /// 挙動位置を設定する.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        /// <param name="pos">挙動位置</param>
        protected void SetBehaviorPos(MusExcSharedDataUnitState unitState, BEHAVIOR_POS pos)
        {
            var viewPoint = unitState.MovingPoint;
            var x = unitState.MovingPoint.X;
            var y = unitState.MovingPoint.Y;
            var amount = unitState.DefUnit.AmountOfBehavior;

            switch (pos)
            {
                case BEHAVIOR_POS.LEFT:       // 左.
                    viewPoint = new Point(x - amount, y);
                    break;

                case BEHAVIOR_POS.RIGHT:      // 右.
                    viewPoint = new Point(x + amount, y);
                    break;

                case BEHAVIOR_POS.UP:         // 上.
                    viewPoint = new Point(x, y - amount);
                    break;

                case BEHAVIOR_POS.DOWN:       // 下.
                    viewPoint = new Point(x, y + amount);
                    break;

                case BEHAVIOR_POS.LEFT_UP:    // 左上.
                    viewPoint = new Point(x - amount, y - amount);
                    break;

                case BEHAVIOR_POS.LEFT_DOWN:  // 左下.
                    viewPoint = new Point(x - amount, y + amount);
                    break;

                case BEHAVIOR_POS.RIGHT_UP:   // 右上.
                    viewPoint = new Point(x + amount, y - amount);
                    break;

                case BEHAVIOR_POS.RIGHT_DOWN: // 右下.
                    viewPoint = new Point(x + amount, y + amount);
                    break;
            }

            unitState.CurrentBehavior = pos;
            unitState.ViewPoint = viewPoint;
        }
    }
}
