using Common.Utilities;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc演算上方向クラス.
    /// </summary>
    public class MusExcExecutorMovementUp : MusExcExecutorMovementBase
    {
        /// <summary>
        /// 初期位置算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetInitPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 新しい座標をセット.
            var x = UtilRandom.Next(GetEndOfRight(state, size));
            state.MovingPoint = new Point(x, size.Height);
            state.CurMovement = MOVEMENT.UP;
        }

        /// <summary>
        /// 移動算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetNextPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 現在位置.
            var cur = state.MovingPoint;

            // Y座標を算出.
            var y = cur.Y;
            if (0 < cur.Y)
            {
                // まだ上に移動可能
                y = cur.Y - state.DefUnit.AmountOfMovement;

                // 新しい座標をセット.
                state.MovingPoint = new Point(cur.X, y);
            }
            else
            {
                // 上端なので、初期位置を算出.
                this.SetInitPoint(state, size);
            }
        }
    }
}
