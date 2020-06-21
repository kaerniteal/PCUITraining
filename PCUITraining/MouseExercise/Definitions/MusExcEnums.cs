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
            HORIZONTAL_REFLECT, // 水平方向(反転)
            VERTICAL_REFLECT,   // 垂直方向(反転)
            CROSS_REFLECT,      // 十字(反転)
            SLANT_REFLECT,      // 斜め(反転)
            LEFT,               // 左
            RIGHT,              // 右
            UP,                 // 上
            DOWN,               // 下
            HORIZONTAL,        // 水平
            VERTICAL,           // 垂直
            CROSS,              // 十字.
            LEFTUP,             // 左上.
            LEFTDOWN,           // 左下.
            RIGHTUP,            // 右上.
            RIGHTDOWN,          // 右下.
            SLANT,              // 斜め.
            RANDOM_10,          // ランダム(10%方向転換).
            RANDOM_20,          // ランダム(20%方向転換).
            RANDOM_25,          // ランダム(25%方向転換).
            RANDOM_30,          // ランダム(30%方向転換).
            RANDOM_35,          // ランダム(35%方向転換).
            RANDOM_40,          // ランダム(40%方向転換).
            RANDOM_50,          // ランダム(50%方向転換).
            RANDOM_60,          // ランダム(60%方向転換).
            RANDOM_70,          // ランダム(70%方向転換).
            RANDOM_75,          // ランダム(75%方向転換).
            RANDOM_80,          // ランダム(80%方向転換).
            RANDOM_90,          // ランダム(90%方向転換).
        }

        /// <summary>
        /// 描画領域の端.
        /// </summary>
        public enum TERMINATED
        {
            NON,    // なし.
            LEFT,   // 左端.
            RIGHT,  // 右端.
            TOP,    // 上端
            BOTTOM, // 下端.
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
