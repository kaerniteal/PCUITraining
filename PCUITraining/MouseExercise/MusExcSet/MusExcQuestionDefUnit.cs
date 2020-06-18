using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.MusExcSet
{
    /// <summary>
    /// MusExc設問ユニット定義クラス.
    /// </summary>
    public class MusExcQuestionDefUnit
    {
        /// <summary>
        /// ユニット名.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 移動方向
        /// </summary>
        public MOVEMENT Movement { get; set; }

        /// <summary>
        /// 移動量
        /// </summary>
        public int AmountOfMovement { get; set; }

        /// <summary>
        /// 挙動
        /// </summary>
        public BEHAVIOR Behavior { get; set; }

        /// <summary>
        /// 変化量.
        /// </summary>
        public int AmountOfBehavior { get; set; }

        /// <summary>
        /// ユニット画像ファイルパス.
        /// </summary>
        public string UnitImageFilePath { get; set; }

        /// <summary>
        /// 出現率.
        /// </summary>
        public int Appearance { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcQuestionDefUnit()
        {
            this.Movement = MOVEMENT.STATIONARY;
            this.AmountOfMovement = 1;
            this.Behavior = BEHAVIOR.NON;
            this.AmountOfBehavior = 1;
            this.UnitImageFilePath = string.Empty;
            this.Appearance = 100;
        }
    }
}
