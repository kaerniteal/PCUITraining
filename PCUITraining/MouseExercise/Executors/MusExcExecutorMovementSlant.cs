using Common.Utilities;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc移動方向演算斜めクラス.
    /// </summary>
    public class MusExcExecutorMovementSlant : MusExcExecutorMovementBase
    {
        /// <summary>
        /// 末端に到達した時に反転するかどうか
        /// </summary>
        private bool Reflect { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="reflect">末端に到達した時に反転するかどうか</param>
        public MusExcExecutorMovementSlant(bool reflect)
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
            // 方向を決定
            MusExcExecutorMovementBase movement = null;
            switch (UtilRandom.Next(4))
            {
                case 0: // 左上.
                    movement = GetMovement(MOVEMENT.LEFTUP);
                    break;

                case 1: // 左下.
                    movement = GetMovement(MOVEMENT.LEFTDOWN);
                    break;

                case 2: // 右上.
                    movement = GetMovement(MOVEMENT.RIGHTUP);
                    break;

                case 3: // 右下.
                default:
                    movement = GetMovement(MOVEMENT.RIGHTDOWN);
                    break;
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
            // 現在の向きを取得.
            var movement = GetMovement(state.CurrentMovement);
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
            var movement = GetMovement(state.CurrentMovement);

            // 反転設定で、末端に到達した場合は.
            var terminated = movement.IsTerminated(state, size);
            if (TERMINATED.NON != terminated && this.Reflect)
            {
                // 方向を入れ替える.
                switch (state.CurrentMovement)
                {
                    case MOVEMENT.LEFTUP:
                        switch (terminated)
                        {
                            case TERMINATED.LEFT: state.CurrentMovement = MOVEMENT.RIGHTUP; break;
                            case TERMINATED.TOP: state.CurrentMovement = MOVEMENT.LEFTDOWN; break;
                        }
                        break;

                    case MOVEMENT.LEFTDOWN:
                        switch (terminated)
                        {
                            case TERMINATED.LEFT: state.CurrentMovement = MOVEMENT.RIGHTDOWN; break;
                            case TERMINATED.BOTTOM: state.CurrentMovement = MOVEMENT.LEFTUP; break;
                        }
                        break;

                    case MOVEMENT.RIGHTUP:
                        switch (terminated)
                        {
                            case TERMINATED.RIGHT: state.CurrentMovement = MOVEMENT.LEFTUP; break;
                            case TERMINATED.TOP: state.CurrentMovement = MOVEMENT.RIGHTDOWN; break;
                        }
                        break;

                    case MOVEMENT.RIGHTDOWN:
                    default:
                        switch (terminated)
                        {
                            case TERMINATED.RIGHT: state.CurrentMovement = MOVEMENT.LEFTDOWN; break;
                            case TERMINATED.BOTTOM: state.CurrentMovement = MOVEMENT.RIGHTUP; break;
                        }
                        break;
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
