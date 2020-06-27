using Common.Utilities;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc移動方向演算右方向クラス.
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
            var y = UtilRandom.Next(GetEndOfBottom(state, size));
            state.MovingPoint = new Point(0, y);
            state.CurrentMovement = MOVEMENT.RIGHT;
        }

        /// <summary>
        /// 描画領域の終端に到達しているかどうか.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        /// <param name="viewSize">描画領域サイズ</param>
        /// <returns>描画領域の端かどうか</returns>
        public override TERMINATED IsTerminated(MusExcSharedDataUnitState state, Size size)
        {
            // 右端に到達しているかをチェック.
            if (GetEndOfRight(state, size) <= state.MovingPoint.X)
            {
                return TERMINATED.RIGHT;
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
            // 右端をチェック.
            if (TERMINATED.NON != this.IsTerminated(state, size))
            {
                // 右端なので、初期位置を算出.
                this.SetInitPoint(state, size);
            }
            else
            {
                // まだ右に移動可能
                var cur = state.MovingPoint;
                var x = cur.X + state.DefUnit.AmountOfMovement;

                // 新しい座標をセット.
                state.MovingPoint = new Point(x, cur.Y);
            }
        }
    }
}
