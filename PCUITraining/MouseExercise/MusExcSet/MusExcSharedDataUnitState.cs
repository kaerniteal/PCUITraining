using System;
using System.Drawing;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.MusExcSet
{
    /// <summary>
    /// 共有データユニットステータス.
    /// </summary>
    public class MusExcSharedDataUnitState
    {
        /// <summary>
        /// ユニットの定義.
        /// </summary>
        public MusExcQuestionDefUnit DefUnit { get; set; }

        /// <summary>
        /// 生存状態.
        /// </summary>
        public LIFE_STATE LifeState { get; set; }

        /// <summary>
        /// 死亡時刻
        /// </summary>
        public DateTime DeadTime { get; set; }

        /// <summary>
        /// ユニットID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 移動中心座標.
        /// </summary>
        public Point MovingPoint { get; set; }

        /// <summary>
        /// 表示座標(移動中心座標に挙動を加えたもの).
        /// </summary>
        public Point ViewPoint { get; set; }

        /// <summary>
        /// 現在の移動方向.
        /// </summary>
        public MOVEMENT CurMovement { get; set; }

        /// <summary>
        /// 表示イメージ.
        /// </summary>
        public Bitmap Image { get; set; }

        /// <summary>
        /// 画像サイズ.
        /// </summary>
        public Size ImageSize { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcSharedDataUnitState()
        {
            this.DefUnit = new MusExcQuestionDefUnit();
            this.LifeState = LIFE_STATE.DEAD;
            this.DeadTime = DateTime.Now;
            this.Id = string.Empty;
            this.MovingPoint = new Point(0, 0);
            this.ViewPoint = new Point(0, 0);
            this.CurMovement = this.DefUnit.Movement;
            this.Image = null;
            this.ImageSize = new Size();
        }
    }
}
