using Common.Utilities;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc移動方向演算左下方向クラス.
    /// </summary>
    public class MusExcExecutorMovementLeftDown : MusExcExecutorMovementBase
    {
        /// <summary>
        /// 初期位置算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetInitPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 右か上かを決定.
            if (UtilRandom.Half())
            {
                // 右からの場合.
                var y = UtilRandom.Next(GetEndOfBottom(state, size));
                state.MovingPoint = new Point(size.Width, y);
            }
            else
            {
                // 上からの場合.
                var x = UtilRandom.Next(GetEndOfRight(state, size));
                state.MovingPoint = new Point(x, 0);
            }

            // 新しい座標をセット.
            state.CurrentMovement = MOVEMENT.LEFTDOWN;
        }

        /// <summary>
        /// 描画領域の終端に到達しているかどうか.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        /// <param name="viewSize">描画領域サイズ</param>
        /// <returns>描画領域の端かどうか</returns>
        public override TERMINATED IsTerminated(MusExcSharedDataUnitState state, Size size)
        {
            // 左端に到達しているかをチェック.
            if (state.MovingPoint.X <= 0)
            {
                return TERMINATED.LEFT;
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
            // 左端,下端をチェック.
            if (TERMINATED.NON != this.IsTerminated(state, size))
            {
                // 左端,下端なので、初期位置を算出.
                this.SetInitPoint(state, size);
            }
            else
            {
                // まだ左下に移動可能
                var cur = state.MovingPoint;
                var x = cur.X - state.DefUnit.AmountOfMovement;
                var y = cur.Y + state.DefUnit.AmountOfMovement;

                // 新しい座標をセット.
                state.MovingPoint = new Point(x, y);
            }
        }
    }
}
