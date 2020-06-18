using Common.Utilities;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc演算右方向クラス.
    /// </summary>
    public class MusExcExecutorMovementRight : MusExcExecutorMovementBase
    {
        /// <summary>
        /// 初期位置算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetInitPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 新しい座標をセット.
            var y = UtilRandom.Next(GetEndOfBottomt(state, size));
            state.MovingPoint = new Point(0, y);
            state.CurMovement = MOVEMENT.RIGHT;
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

            // X座標を算出.
            var x = cur.X;
            if (cur.X + state.Image.Width < size.Width)
            {
                // まだ右に移動可能
                x = cur.X + state.DefUnit.AmountOfMovement;

                // 新しい座標をセット.
                state.MovingPoint = new Point(x, cur.Y);
            }
            else
            {
                // 右端なので、初期位置を算出.
                this.SetInitPoint(state, size);
            }
        }
    }
}
