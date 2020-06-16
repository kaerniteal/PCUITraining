namespace MouseExercise.Definitions
{
    /// <summary>
    /// ENUM定義クラス.
    /// </summary>
    public static class MusExcEnums
    {
        /// <summary>
        /// 難易度
        /// </summary>
        public enum DIFFICULTY
        {
            NON,
            VERY_EASY,
            EASY,
            NORMAL,
            HARD,
            VERY_HARD
        }

        /// <summary>
        /// 背景タイプ.
        /// </summary>
        public enum BG_TYPE
        {
            COLOR,
            IMAGE,
        }

        /// <summary>
        /// 挙動
        /// </summary>
        public enum BEHAVIOR
        {
            STATIONARY,
            HORIZONTAL,
            VERTICAL,
            WINDING,
            CIRCLE,
        }

        /// <summary>
        /// ユニット状態
        /// </summary>
        public enum LIFE_STATE
        {
            LIVING,
            DEAD,
        }
    }
}
