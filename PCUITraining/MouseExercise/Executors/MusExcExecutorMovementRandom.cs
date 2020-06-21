using Common.Utilities;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc演算ランダム方向クラス.
    /// </summary>
    public class MusExcExecutorMovementRandom : MusExcExecutorMovementBase
    {
        /// <summary>
        /// ランダム方向候補リスト.
        /// </summary>
        private static readonly MOVEMENT[] MovementArray = {
            MOVEMENT.LEFT,
            MOVEMENT.RIGHT,
            MOVEMENT.UP,
            MOVEMENT.DOWN,
            MOVEMENT.LEFTUP,
            MOVEMENT.LEFTDOWN,
            MOVEMENT.RIGHTUP,
            MOVEMENT.RIGHTDOWN,
        };

        /// <summary>
        /// 方向変更確率.
        /// </summary>
        private int Percent { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="percent">方向変更確率</param>
        public MusExcExecutorMovementRandom(int percent)
        {
            this.Percent = percent;
        }

        /// <summary>
        /// 初期位置算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetInitPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 初期位置は静止を使用してランダムに配置.
            var movement = GetMovement(MOVEMENT.STATIONARY);
            movement.SetInitPoint(state, size);

            // 現在方向はランダムで決定する.
            state.CurMovement = MovementArray.GetRandom();
        }

        /// <summary>
        /// 描画領域の終端に到達しているかどうか.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        /// <param name="viewSize">描画領域サイズ</param>
        /// <returns>描画領域の端かどうか</returns>
        public override TERMINATED IsTerminated(MusExcSharedDataUnitState state, Size size)
        {
            // 現在の向きを取得.
            var movement = GetMovement(state.CurMovement);
            return movement.IsTerminated(state, size);
        }

        /// <summary>
        /// 移動算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetNextPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 現在の向きでMovementを取得.
            var movement = GetMovement(state.CurMovement);

            // 確率で方向を変える.
            if (UtilRandom.Next(100) < this.Percent)
            {
                movement = GetMovement(MovementArray.GetRandom());
            }

            // 末端に到達している場合は初期化.
            if (TERMINATED.NON != movement.IsTerminated(state, size))
            {
                this.SetInitPoint(state, size);
            }
            else
            {
                // 上記以外の場合はそのままの向きで動作.
                movement.SetNextPoint(state, size);
            }
        }
    }
}
