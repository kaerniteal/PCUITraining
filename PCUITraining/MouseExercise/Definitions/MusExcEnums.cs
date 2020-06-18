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
        /// 移動方向
        /// </summary>
        public enum MOVEMENT
        {
            STATIONARY,         // 静止
            HORIZONTAL_REFLECT, // 水平方向(反射)
            VERTICAL_REFLECT,   // 水平方向(反射)
            CROSS_REFLECT,      // 十字(反射)
            SLANT_REFLECT,      // 斜め(反射)
            LEFT,               // 左
            RIGHT,              // 右
            UP,                 // 上
            DOWN,               // 下
            HORIZONTAL,        // 水平
            VERTICAL,           // 垂直
            CROSS,              // 十字.
            SLANT,              // 斜め.
            RANDOM,             // ランダム.
        }

        /// <summary>
        /// 挙動
        /// </summary>
        public enum BEHAVIOR
        {
            NON,        // なし
            SWAY_LR,    // 左右揺れ
            SWAY_UD,    // 上下揺れ
            CIRCLE,     // 円運動
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
