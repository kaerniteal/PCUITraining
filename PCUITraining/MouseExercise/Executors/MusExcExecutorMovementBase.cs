using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc演算基底クラス.
    /// </summary>
    public abstract class MusExcExecutorMovementBase
    {
        /// <summary>
        /// 初期位置算出処理.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        /// <param name="viewSize">描画領域サイズ</param>
        public abstract void SetInitPoint(MusExcSharedDataUnitState unitState, Size viewSize);

        /// <summary>
        /// 描画領域の終端に到達しているかどうか.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        /// <param name="viewSize">描画領域サイズ</param>
        /// <returns>描画領域の端かどうか</returns>
        public abstract TERMINATED IsTerminated(MusExcSharedDataUnitState state, Size size);

        /// <summary>
        /// 移動算出処理.
        /// </summary>
        /// <param name="unitState">ユニットステータス</param>
        /// <param name="viewSize">描画領域サイズ</param>
        public abstract void SetNextPoint(MusExcSharedDataUnitState state, Size size);


        /// <summary>
        /// 演算クラスを取得する(ファクトリ).
        /// </summary>
        /// <param name="movement">移動方向</param>
        /// <returns>演算クラス</returns>
        public static MusExcExecutorMovementBase GetMovement(MOVEMENT movement)
        {
            switch(movement)
            {
                case MOVEMENT.STATIONARY:         // 静止
                    return new MusExcExecutorMovementStationary();

                case MOVEMENT.HORIZONTAL_REFLECT: // 水平方向(反転)
                    return new MusExcExecutorMovementHorizontal(true);

                case MOVEMENT.VERTICAL_REFLECT:   // 垂直方向(反転)
                    return new MusExcExecutorMovementVertical(true);

                case MOVEMENT.CROSS_REFLECT:      // 十字(反転)
                    return new MusExcExecutorMovementCross(true);

                case MOVEMENT.SLANT_REFLECT:      // 斜め(反転)
                    return new MusExcExecutorMovementSlant(true);

                case MOVEMENT.LEFT:               // 左
                    return new MusExcExecutorMovementLeft();

                case MOVEMENT.RIGHT:              // 右
                    return new MusExcExecutorMovementRight();

                case MOVEMENT.UP:                 // 上
                    return new MusExcExecutorMovementUp();

                case MOVEMENT.DOWN:               // 下
                    return new MusExcExecutorMovementDown();

                case MOVEMENT.HORIZONTAL:         // 水平
                    return new MusExcExecutorMovementHorizontal(false);

                case MOVEMENT.VERTICAL:           // 垂直
                    return new MusExcExecutorMovementVertical(false);

                case MOVEMENT.CROSS:              // 十字.
                    return new MusExcExecutorMovementCross(false);

                case MOVEMENT.LEFTUP:             // 左上.
                    return new MusExcExecutorMovementLeftUp();

                case MOVEMENT.LEFTDOWN:           // 左下.
                    return new MusExcExecutorMovementLeftDown();

                case MOVEMENT.RIGHTUP:            // 右上.
                    return new MusExcExecutorMovementRightUp();

                case MOVEMENT.RIGHTDOWN:          // 右下.
                    return new MusExcExecutorMovementRightDown();

                case MOVEMENT.SLANT:              // 斜め.
                    return new MusExcExecutorMovementSlant(false);

                case MOVEMENT.RANDOM_10:          // ランダム(10%方向転換).
                    return new MusExcExecutorMovementRandom(10);

                case MOVEMENT.RANDOM_20:          // ランダム(20%方向転換).
                    return new MusExcExecutorMovementRandom(20);

                case MOVEMENT.RANDOM_25:          // ランダム(25%方向転換).
                    return new MusExcExecutorMovementRandom(25);

                case MOVEMENT.RANDOM_30:          // ランダム(30%方向転換).
                    return new MusExcExecutorMovementRandom(30);

                case MOVEMENT.RANDOM_35:          // ランダム(35%方向転換).
                    return new MusExcExecutorMovementRandom(35);

                case MOVEMENT.RANDOM_40:          // ランダム(40%方向転換).
                    return new MusExcExecutorMovementRandom(40);

                case MOVEMENT.RANDOM_50:          // ランダム(50%方向転換).
                    return new MusExcExecutorMovementRandom(50);

                case MOVEMENT.RANDOM_60:          // ランダム(60%方向転換).
                    return new MusExcExecutorMovementRandom(60);

                case MOVEMENT.RANDOM_70:          // ランダム(70%方向転換).
                    return new MusExcExecutorMovementRandom(70);

                case MOVEMENT.RANDOM_75:          // ランダム(75%方向転換).
                    return new MusExcExecutorMovementRandom(75);

                case MOVEMENT.RANDOM_80:          // ランダム(80%方向転換).
                    return new MusExcExecutorMovementRandom(80);

                case MOVEMENT.RANDOM_90:          // ランダム(90%方向転換).
                    return new MusExcExecutorMovementRandom(90);

                default:
                    return new MusExcExecutorMovementRandom(100);
            }
        }

        /// <summary>
        /// 右端を取得.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        protected static int GetEndOfRight(MusExcSharedDataUnitState state, Size size)
        {
            var er = size.Width - state.ImageSize.Width;
            if (er < 0)
            {
                er = 0;
            }

            return er;
        }

        /// <summary>
        /// 下端を取得.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        protected static int GetEndOfBottom(MusExcSharedDataUnitState state, Size size)
        {
            var eb = size.Height - state.ImageSize.Height;
            if (eb < 0)
            {
                eb = 0;
            }

            return eb;
        }
    }
}
