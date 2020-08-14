using System.Collections.Generic;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    /// <summary>
    /// 昆虫採集セット－設問定義リスト.
    /// </summary>
    public static class InsectCollectingSetQuestionList
    {
        /// <summary>
        /// 設問定義リスト.
        /// </summary>
        public static List<MusExcQuestionDef> QuestionList = null;


        /// <summary>
        /// 設問リスト取得.
        /// </summary>
        /// <returns>設問</returns>
        public static List<MusExcQuestionDef> GetQuestionList()
        {
            if (null != QuestionList)
            {
                return QuestionList;
            }

            QuestionList = new List<MusExcQuestionDef>();

            // 01_01 草むらカマキリ
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.VERY_EASY,
                UnitNum = 3,
                MaxNum = 3,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\01_01_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "鎌研ぎカマキリ大",
                            Movement = MOVEMENT.STATIONARY,
                            Score = 100,
                            UnitImageFilePath = @".\MusExcResorce\01_01_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "飛アニメカマキリ小(レア)",
                            Movement = MOVEMENT.UP,
                            AmountOfMovement = 3,
                            Score = 500,
                            UnitImageFilePath = @".\MusExcResorce\01_01_unit02.gif",
                            Appearance = 5,
                        },
                    },
            });

            // 01_02 木のセミ
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.VERY_EASY,
                UnitNum = 3,
                MaxNum = 3,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\01_02_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "競鳴セミ大",
                            Movement = MOVEMENT.STATIONARY,
                            Score = 100,
                            UnitImageFilePath = @".\MusExcResorce\01_02_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "飛セミ小(レア)",
                            Movement = MOVEMENT.HORIZONTAL,
                            AmountOfMovement = 3,
                            Score = 500,
                            UnitImageFilePath = @".\MusExcResorce\01_02_unit02.gif",
                            Appearance = 5,
                        },
                    },
            });

            // 01_03 水辺のトンボ
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.VERY_EASY,
                UnitNum = 3,
                MaxNum = 3,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\01_03_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "吸水オニヤンマ大",
                            Movement = MOVEMENT.STATIONARY,
                            Score = 100,
                            UnitImageFilePath = @".\MusExcResorce\01_03_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "吸水糸トンボ小(レア)",
                            Movement = MOVEMENT.STATIONARY,
                            Score = 500,
                            UnitImageFilePath = @".\MusExcResorce\01_03_unit02.gif",
                            Appearance = 5,
                        },
                    },
            });

            // 02_01 暗闇のホタル
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.EASY,
                UnitNum = 5,
                MaxNum = 10,
                BgType = BG_TYPE.COLOR,
                BgColorR = 70,
                BgColorG = 71,
                BgColorB = 71,
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "ホタル",
                            Movement = MOVEMENT.SLANT_REFLECT,
                            AmountOfMovement = 3,
                            Score = 200,
                            UnitImageFilePath = @".\MusExcResorce\02_01_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "モルフォ蝶(激レア)",
                            Movement = MOVEMENT.LEFT,
                            AmountOfMovement = 10,
                            Score = 1000,
                            UnitImageFilePath = @".\MusExcResorce\02_01_unit02.gif",
                            Appearance = 1,
                        },
                    },
            });

            // 02_02 夏山のトンボ
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.EASY,
                UnitNum = 3,
                MaxNum = 10,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\02_02_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "飛オニヤンマ大",
                            Movement = MOVEMENT.SLANT_REFLECT,
                            AmountOfMovement = 3,
                            Score = 200,
                            UnitImageFilePath = @".\MusExcResorce\02_02_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "飛糸トンボ小(激レア)",
                            Movement = MOVEMENT.SLANT,
                            AmountOfMovement = 3,
                            Score = 1000,
                            UnitImageFilePath = @".\MusExcResorce\02_02_unit02.gif",
                            Appearance = 1,
                        },
                    },
            });

            // 02_03 オレンジアップ花とハチ
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.EASY,
                UnitNum = 3,
                MaxNum = 10,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\02_03_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "巨大アイコン蜂",
                            Movement = MOVEMENT.CROSS_REFLECT,
                            AmountOfMovement = 3,
                            Score = 200,
                            UnitImageFilePath = @".\MusExcResorce\02_03_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "アイコン蜂小(レア)",
                            Movement = MOVEMENT.SLANT_REFLECT,
                            AmountOfMovement = 4,
                            Score = 500,
                            UnitImageFilePath = @".\MusExcResorce\02_03_unit02.gif",
                            Appearance = 5,
                        },
                    },
            });

            // 03_01 AAワールド
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.NORMAL,
                UnitNum = 5,
                MaxNum = 10,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\03_01_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "AA バッタ",
                            Movement = MOVEMENT.LEFT,
                            AmountOfMovement = 3,
                            Score = 300,
                            UnitImageFilePath = @".\MusExcResorce\03_01_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "AA イモムシ",
                            Movement = MOVEMENT.LEFT,
                            AmountOfMovement = 2,
                            Score = 300,
                            UnitImageFilePath = @".\MusExcResorce\03_01_unit02.gif",
                            Appearance = 63,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "AA カマキリ",
                            Movement = MOVEMENT.STATIONARY,
                            AmountOfMovement = 3,
                            Score = 300,
                            UnitImageFilePath = @".\MusExcResorce\03_01_unit03.gif",
                            Appearance = 26,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "AA ピンクトンボ(レア)",
                            Movement = MOVEMENT.LEFT,
                            AmountOfMovement = 5,
                            Score = 500,
                            UnitImageFilePath = @".\MusExcResorce\03_01_unit04.gif",
                            Appearance = 6,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "透明イモムシ(激レア)",
                            Movement = MOVEMENT.LEFT,
                            AmountOfMovement = 5,
                            Score = 1000,
                            UnitImageFilePath = @".\MusExcResorce\03_01_unit09.gif",
                            Appearance = 1,
                        },
                    },
            });

            // 03_02 チューリップと蜂達
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.NORMAL,
                UnitNum = 5,
                MaxNum = 10,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\03_02_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "アニメハチ上",
                            Movement = MOVEMENT.VERTICAL,
                            AmountOfMovement = 4,
                            Score = 300,
                            UnitImageFilePath = @".\MusExcResorce\03_02_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "アニメハチ右",
                            Movement = MOVEMENT.RIGHT,
                            AmountOfMovement = 4,
                            Score = 300,
                            UnitImageFilePath = @".\MusExcResorce\03_02_unit02.gif",
                            Appearance = 67,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "アニメハチ左",
                            Movement = MOVEMENT.LEFT,
                            AmountOfMovement = 4,
                            Score = 300,
                            UnitImageFilePath = @".\MusExcResorce\03_02_unit03.gif",
                            Appearance = 34,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "キラキラアニメハチ(激レア)",
                            Movement = MOVEMENT.SLANT,
                            AmountOfMovement = 5,
                            Score = 1000,
                            UnitImageFilePath = @".\MusExcResorce\03_02_unit04.gif",
                            Appearance = 1,
                        },
                    },
            });

            // 03_03 甲虫の世界
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.NORMAL,
                UnitNum = 3,
                MaxNum = 10,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\03_03_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "カブトムシ小",
                            Movement = MOVEMENT.UP,
                            AmountOfMovement = 4,
                            Score = 300,
                            UnitImageFilePath = @".\MusExcResorce\03_03_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "クワガタムシ小",
                            Movement = MOVEMENT.UP,
                            AmountOfMovement = 4,
                            Score = 300,
                            UnitImageFilePath = @".\MusExcResorce\03_03_unit02.gif",
                            Appearance = 53,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "カミキリムシ小(レア)",
                            Movement = MOVEMENT.HORIZONTAL,
                            AmountOfMovement = 5,
                            Score = 500,
                            UnitImageFilePath = @".\MusExcResorce\03_03_unit03.gif",
                            Appearance = 6,
                        },
                    },
            });

            // 04_01 赤い花と白い蝶
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.HARD,
                UnitNum = 5,
                MaxNum = 5,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\04_01_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "白い蝶小",
                            Movement = MOVEMENT.RANDOM_50,
                            AmountOfMovement = 5,
                            Behavior = BEHAVIOR.NON,
                            Score = 400,
                            UnitImageFilePath = @".\MusExcResorce\04_01_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "ピンクのアイコン蝶(激レア)",
                            Movement = MOVEMENT.RANDOM_50,
                            AmountOfMovement = 5,
                            Behavior = BEHAVIOR.SWAY_LR,
                            AmountOfBehavior = 5,
                            Score = 2000,
                            UnitImageFilePath = @".\MusExcResorce\04_01_unit02.gif",
                            Appearance = 1,
                        },
                    },
            });

            // 04_02 低草とテントウムシ.
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.HARD,
                UnitNum = 5,
                MaxNum = 10,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\04_02_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "テントウムシ",
                            Movement = MOVEMENT.RANDOM_10,
                            AmountOfMovement = 5,
                            Score = 400,
                            UnitImageFilePath = @".\MusExcResorce\04_02_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "テントウムシ裏(激レア)",
                            Movement = MOVEMENT.RANDOM_20,
                            AmountOfMovement = 5,
                            Score = 2000,
                            UnitImageFilePath = @".\MusExcResorce\04_02_unit02.gif",
                            Appearance = 1,
                        },
                    },
            });

            // 05_01 高原蝶々.
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.VERY_HARD,
                UnitNum = 5,
                MaxNum = 10,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\05_01_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "赤アゲハ",
                            Movement = MOVEMENT.RANDOM_50,
                            AmountOfMovement = 10,
                            Behavior = BEHAVIOR.SWAY_LR,
                            AmountOfBehavior = 10,
                            Score = 500,
                            UnitImageFilePath = @".\MusExcResorce\05_01_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "青アゲハ(レア)",
                            Movement = MOVEMENT.RANDOM_20,
                            AmountOfMovement = 15,
                            Behavior = BEHAVIOR.SWAY_LR,
                            AmountOfBehavior = 10,
                            Score = 1000,
                            UnitImageFilePath = @".\MusExcResorce\05_01_unit02.gif",
                            Appearance = 10,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "黒アゲハ(激レア)",
                            Movement = MOVEMENT.RANDOM_10,
                            AmountOfMovement = 20,
                            Behavior = BEHAVIOR.SWAY_LR,
                            AmountOfBehavior = 10,
                            Score = 2000,
                            UnitImageFilePath = @".\MusExcResorce\05_01_unit03.gif",
                            Appearance = 1,
                        },
                    },
            });

            // 05_02 マーガレット畑のハチ.
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.VERY_HARD,
                UnitNum = 5,
                MaxNum = 10,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\05_02_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "ハッチ蜂",
                            Movement = MOVEMENT.RANDOM_10,
                            AmountOfMovement = 10,
                            Score = 500,
                            UnitImageFilePath = @".\MusExcResorce\05_02_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "チビグルグル蝶(激レア)",
                            Movement = MOVEMENT.RANDOM_10,
                            AmountOfMovement = 15,
                            Behavior = BEHAVIOR.SWAY_LR,
                            AmountOfBehavior = 10,
                            Score = 2000,
                            UnitImageFilePath = @".\MusExcResorce\05_02_unit02.gif",
                            Appearance = 1,
                        },
                    },
            });

            // 05_03 チューリップ畑の蝶.
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.VERY_HARD,
                UnitNum = 5,
                MaxNum = 10,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\05_03_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "小モルフォ蝶",
                            Movement = MOVEMENT.RANDOM_50,
                            AmountOfMovement = 10,
                            Behavior = BEHAVIOR.SWAY_LR,
                            AmountOfBehavior = 10,
                            Score = 500,
                            UnitImageFilePath = @".\MusExcResorce\05_03_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "トノサマバッタ(激レア)",
                            Movement = MOVEMENT.UP,
                            AmountOfMovement = 5,
                            Score = 2000,
                            UnitImageFilePath = @".\MusExcResorce\05_03_unit02.gif",
                            Appearance = 1,
                        },
                    },
            });

            // 05_04 赤い花アップの蝶.
            QuestionList.Add(new MusExcQuestionDef
            {
                Difficulty = DIFFICULTY.VERY_HARD,
                UnitNum = 5,
                MaxNum = 10,
                BgType = BG_TYPE.IMAGE,
                BgImageFilePath = @".\MusExcResorce\05_04_bg.jpg",
                UnitList = new List<MusExcQuestionDefUnit>
                    {
                        new MusExcQuestionDefUnit
                        {
                            Name = "小青蝶",
                            Movement = MOVEMENT.RANDOM_50,
                            AmountOfMovement = 10,
                            Behavior = BEHAVIOR.SWAY_LR,
                            AmountOfBehavior = 10,
                            Score = 500,
                            UnitImageFilePath = @".\MusExcResorce\05_04_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "バイバイハチ(激レア)",
                            Movement = MOVEMENT.RANDOM_10,
                            AmountOfMovement = 10,
                            Score = 2000,
                            UnitImageFilePath = @".\MusExcResorce\05_04_unit02.gif",
                            Appearance = 1,
                        },
                    },
            });

            return QuestionList;
        }
    }
}
