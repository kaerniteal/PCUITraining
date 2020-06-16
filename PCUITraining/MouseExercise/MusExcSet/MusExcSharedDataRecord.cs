using System;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.MusExcSet
{
    /// <summary>
    /// 共有データユニットステータス.
    /// </summary>
    public class MusExcSharedDataUnitState
    {
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
        /// X座標.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y座標
        /// </summary>
        public int Y { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcSharedDataUnitState()
        {
            this.LifeState = LIFE_STATE.DEAD;
            this.DeadTime = DateTime.Now;
            this.Id = string.Empty;
            this.X = 0;
            this.Y = 0;
        }
    }
}
