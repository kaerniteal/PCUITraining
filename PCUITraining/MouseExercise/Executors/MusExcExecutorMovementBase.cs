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
        public static MusExcExecutorMovementBase GetCalculator(MOVEMENT movement)
        {
            switch(movement)
            {
                case MOVEMENT.STATIONARY:         // 静止
                    return new MusExcExecutorMovementStationary();

                case MOVEMENT.HORIZONTAL_REFLECT: // 水平方向(反射)
                case MOVEMENT.VERTICAL_REFLECT:   // 水平方向(反射)
                case MOVEMENT.CROSS_REFLECT:      // 十字(反射)
                case MOVEMENT.SLANT_REFLECT:      // 斜め(反射)
                case MOVEMENT.LEFT:               // 左
                    return new MusExcExecutorMovementLeft();

                case MOVEMENT.RIGHT:              // 右
                    return new MusExcExecutorMovementRight();

                case MOVEMENT.UP:                 // 上
                    return new MusExcExecutorMovementUp();

                case MOVEMENT.DOWN:               // 下
                case MOVEMENT.HORIZONTAL:         // 水平
                    return new MusExcExecutorMovementHorizontal();

                case MOVEMENT.VERTICAL:           // 垂直
                case MOVEMENT.CROSS:              // 十字.
                case MOVEMENT.SLANT:              // 斜め.
                case MOVEMENT.RANDOM:             // ランダム.

                default:
                    return new MusExcExecutorMovementStationary();
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
            var er = size.Width - state.Image.Size.Width;
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
        protected static int GetEndOfBottomt(MusExcSharedDataUnitState state, Size size)
        {
            var eb = size.Height - state.Image.Size.Height;
            if (eb < 0)
            {
                eb = 0;
            }

            return eb;
        }
    }
}
