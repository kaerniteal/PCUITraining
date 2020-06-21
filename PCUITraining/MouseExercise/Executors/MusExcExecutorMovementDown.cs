using Common.Utilities;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc演算下方向クラス.
    /// </summary>
    public class MusExcExecutorMovementDown : MusExcExecutorMovementBase
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
            state.MovingPoint = new Point(x, 0);
            state.CurMovement = MOVEMENT.DOWN;
        }

        /// <summary>
        /// 描画領域の終端に到達しているかどうか.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        /// <param name="viewSize">描画領域サイズ</param>
        /// <returns>描画領域の端かどうか</returns>
        public override TERMINATED IsTerminated(MusExcSharedDataUnitState state, Size size)
        {
            // 下端に到達しているかをチェック.
            if (GetEndOfBottom(state, size) <= state.MovingPoint.Y)
            {
                return TERMINATED.BOTTOM;
            }

            return TERMINATED.NON;
        }

        /// <summary>
        /// 移動算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetNextPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 下端をチェック.
            if (TERMINATED.NON != this.IsTerminated(state, size))
            {
                // 下端なので、初期位置を算出.
                this.SetInitPoint(state, size);
            }
            else
            {
                // まだ下に移動可能
                var cur = state.MovingPoint;
                var y = cur.Y + state.DefUnit.AmountOfMovement;

                // 新しい座標をセット.
                state.MovingPoint = new Point(cur.X, y);
            }
        }
    }
}
