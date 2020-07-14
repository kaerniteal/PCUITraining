using Common.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    /// <summary>
    /// 昆虫採集セット－設問定義リスト.
    /// </summary>
    public class InsectCollectingSetQuestionList
    {
        /// <summary>
        /// リソースファイル.
        /// </summary>
        private static readonly string FileName = @".\MusExcSet\InsectCollectingSet\InsectCollectingSetQuestionList.dat";

        /// <summary>
        /// 使用ガイド
        /// </summary>
        public string[] Usage { get; set; }

        /// <summary>
        /// 設問定義リスト.
        /// </summary>
        public List<MusExcQuestionDef> QuestionList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public InsectCollectingSetQuestionList()
        {
            this.Usage = CreateUsage();
            this.QuestionList = new List<MusExcQuestionDef>();
        }

        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <remarks>失敗時にはNULLを返す</remarks>
        /// <returns>正答テーブル</returns>
        public static InsectCollectingSetQuestionList Load()
        {
            var qList = new InsectCollectingSetQuestionList();

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(FileName))
            {
                try
                {
                    qList = FileName.JsonLoad<InsectCollectingSetQuestionList>();
                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox(@"ファイル[{0}]の読み込みに失敗しました".Fmt(FileName));
                }
            }

            // 下記の２ケースを想定して毎回出力する
            // ・読み込んだ設定ファイルに項目が不足している場合.
            // ・設定ファイルが存在しない場合.
            qList.Save();

            return qList;
        }

        /// <summary>
        /// セーブ処理.
        /// </summary>
        public bool Save()
        {
            try
            {
                this.Usage = CreateUsage();
                this.AddNewTemplate();

                this.JsonSave(FileName);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox(@"ファイル[{0}]の保存に失敗しました".Fmt(FileName));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 使用ガイドを生成する.
        /// </summary>
        /// <returns>使用ガイド文字列</returns>
        public static string[] CreateUsage()
        {
            return new string[]
            {
                "**************************************",
                "****     このファイルの使い方     ****",
                "**************************************",
                "* Difficulty",
                "*   {0}:Very easy".Fmt((int)DIFFICULTY.VERY_EASY),
                "*   {0}:Easy".Fmt((int)DIFFICULTY.EASY),
                "*   {0}:Normal".Fmt((int)DIFFICULTY.NORMAL),
                "*   {0}:Hard".Fmt((int)DIFFICULTY.HARD),
                "*   {0}:Very hard".Fmt((int)DIFFICULTY.VERY_HARD),
                "* BgType",
                "*   {0}:Color".Fmt((int)BG_TYPE.COLOR),
                "*   {0}:Image".Fmt((int)BG_TYPE.IMAGE),
                "* Movement",
                "*   {0}:静止".Fmt((int)MOVEMENT.STATIONARY),
                "*   {0}:水平方向(反転)".Fmt((int)MOVEMENT.HORIZONTAL_REFLECT),
                "*   {0}:水平方向(反転)".Fmt((int)MOVEMENT.VERTICAL_REFLECT),
                "*   {0}:十字(反転)".Fmt((int)MOVEMENT.CROSS_REFLECT),
                "*   {0}:斜め(反転)".Fmt((int)MOVEMENT.SLANT_REFLECT),
                "*   {0}:左".Fmt((int)MOVEMENT.LEFT),
                "*   {0}:右".Fmt((int)MOVEMENT.RIGHT),
                "*   {0}:上".Fmt((int)MOVEMENT.UP),
                "*   {0}:下".Fmt((int)MOVEMENT.DOWN),
                "*   {0}:水平".Fmt((int)MOVEMENT.HORIZONTAL),
                "*   {0}:垂直".Fmt((int)MOVEMENT.VERTICAL),
                "*   {0}:十字".Fmt((int)MOVEMENT.CROSS),
                "*   {0}:左上".Fmt((int)MOVEMENT.LEFTUP),
                "*   {0}:左下".Fmt((int)MOVEMENT.LEFTDOWN),
                "*   {0}:右上".Fmt((int)MOVEMENT.RIGHTUP),
                "*   {0}:右下".Fmt((int)MOVEMENT.RIGHTDOWN),
                "*   {0}:斜め".Fmt((int)MOVEMENT.SLANT),
                "*   {0}:ランダム(10%方向転換)".Fmt((int)MOVEMENT.RANDOM_10),
                "*   {0}:ランダム(20%方向転換)".Fmt((int)MOVEMENT.RANDOM_20),
                "*   {0}:ランダム(25%方向転換)".Fmt((int)MOVEMENT.RANDOM_25),
                "*   {0}:ランダム(30%方向転換)".Fmt((int)MOVEMENT.RANDOM_30),
                "*   {0}:ランダム(35%方向転換)".Fmt((int)MOVEMENT.RANDOM_35),
                "*   {0}:ランダム(40%方向転換)".Fmt((int)MOVEMENT.RANDOM_40),
                "*   {0}:ランダム(50%方向転換)".Fmt((int)MOVEMENT.RANDOM_50),
                "*   {0}:ランダム(60%方向転換)".Fmt((int)MOVEMENT.RANDOM_60),
                "*   {0}:ランダム(70%方向転換)".Fmt((int)MOVEMENT.RANDOM_70),
                "*   {0}:ランダム(75%方向転換)".Fmt((int)MOVEMENT.RANDOM_75),
                "*   {0}:ランダム(80%方向転換)".Fmt((int)MOVEMENT.RANDOM_80),
                "*   {0}:ランダム(90%方向転換)".Fmt((int)MOVEMENT.RANDOM_90),
                "* Behavior",
                "*   {0}:なし".Fmt((int)BEHAVIOR.NON),
                "*   {0}:左右揺れ".Fmt((int)BEHAVIOR.SWAY_LR),
                "*   {0}:上下揺れ".Fmt((int)BEHAVIOR.SWAY_UD),
                "*   {0}:円運動".Fmt((int)BEHAVIOR.CIRCLE),
                "**************************************",
            };
        }

        /// <summary>
        /// 保存時にテンプレートを追加する.
        /// </summary>
        private void AddNewTemplate()
        {
            this.QuestionList.Clear();

            // 01_01 草むらカマキリ
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
            this.QuestionList.Add(new MusExcQuestionDef
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
        }
    }
}
