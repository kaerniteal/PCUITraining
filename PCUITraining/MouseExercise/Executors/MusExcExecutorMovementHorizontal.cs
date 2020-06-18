using Common.Utilities;
using MouseExercise.MusExcSet;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Executors
{
    /// <summary>
    /// MusExc演算左右方向クラス.
    /// </summary>
    public class MusExcExecutorMovementHorizontal : MusExcExecutorMovementBase
    {
        /// <summary>
        /// 初期位置算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetInitPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 左右のどちらかをランダムで決定.
            MusExcExecutorMovementBase movement = null;
            if (0 == UtilRandom.Next(2))
            {
                movement = GetCalculator(MOVEMENT.LEFT);
            }
            else
            {
                movement = GetCalculator(MOVEMENT.RIGHT);
            }

            // 決定した方向で初期化.
            movement.SetInitPoint(state, size);
        }

        /// <summary>
        /// 移動算出処理.
        /// </summary>
        /// <param name="state">算出対象ユニットステータス</param>
        /// <param name="present">描画領域サイズ</param>
        public override void SetNextPoint(MusExcSharedDataUnitState state, Size size)
        {
            // 左右のどちらかを取得.
            var movement = GetCalculator(state.CurMovement);
            movement.SetNextPoint(state, size);
        }
    }
}
