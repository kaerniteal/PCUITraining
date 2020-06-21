using Common.Utilities;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc演算右下方向クラス.
    /// </summary>
    public class MusExcExecutorMovementRightDown : MusExcExecutorMovementBase
    {
        /// <summary>
        /// 初期位置算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetInitPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 左か上かを決定.
            if (UtilRandom.Half())
            {
                // 左からの場合.
                var y = UtilRandom.Next(GetEndOfBottom(state, size));
                state.MovingPoint = new Point(0, y);
            }
            else
            {
                // 上からの場合.
                var x = UtilRandom.Next(GetEndOfRight(state, size));
                state.MovingPoint = new Point(x, 0);
            }

            // 新しい座標をセット.
            state.CurMovement = MOVEMENT.RIGHTDOWN;
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
            // 右端,下端をチェック.
            if (TERMINATED.NON != this.IsTerminated(state, size))
            {
                // 右端,下端なので、初期位置を算出.
                this.SetInitPoint(state, size);
            }
            else
            {
                // まだ右下に移動可能
                var cur = state.MovingPoint;
                var x = cur.X + state.DefUnit.AmountOfMovement;
                var y = cur.Y + state.DefUnit.AmountOfMovement;

                // 新しい座標をセット.
                state.MovingPoint = new Point(x, y);
            }
        }
    }
}
