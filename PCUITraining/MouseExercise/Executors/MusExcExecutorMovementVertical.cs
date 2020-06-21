using Common.Utilities;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc演算垂直方向クラス.
    /// </summary>
    public class MusExcExecutorMovementVertical : MusExcExecutorMovementBase
    {
        /// <summary>
        /// 末端に到達した時に反転するかどうか
        /// </summary>
        private bool Reflect { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="reflect">末端に到達した時に反転するかどうか</param>
        public MusExcExecutorMovementVertical(bool reflect)
        {
            this.Reflect = reflect;
        }

        /// <summary>
        /// 初期位置算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetInitPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 上下のどちらかをランダムで決定.
            MusExcExecutorMovementBase movement = null;
            if (UtilRandom.Half())
            {
                movement = GetMovement(MOVEMENT.UP);
            }
            else
            {
                movement = GetMovement(MOVEMENT.DOWN);
            }

            // 決定した方向で初期化.
            movement.SetInitPoint(state, size);
        }

        /// <summary>
        /// 描画領域の終端に到達しているかどうか.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        /// <param name="viewSize">描画領域サイズ</param>
        /// <returns>描画領域の端かどうか</returns>
        public override TERMINATED IsTerminated(MusExcSharedDataUnitState state, Size size)
        {
            // 左右方向の現在の向きを取得.
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

            // 反転設定で、末端に到達した場合は.
            if (TERMINATED.NON != movement.IsTerminated(state, size) && this.Reflect)
            {
                // 上下を入れ替える.
                if (MOVEMENT.UP == state.CurMovement)
                {
                    state.CurMovement = MOVEMENT.DOWN;
                }
                else
                {
                    state.CurMovement = MOVEMENT.UP;
                }
            }
            else
            {
                // 上記以外の場合はそのままの向きで動作.
                movement.SetNextPoint(state, size);
            }
        }
    }
}
