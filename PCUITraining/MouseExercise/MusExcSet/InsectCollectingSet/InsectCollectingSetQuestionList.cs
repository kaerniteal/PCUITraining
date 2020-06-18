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
                "*   {0}:水平方向(反射)".Fmt((int)MOVEMENT.HORIZONTAL_REFLECT),
                "*   {0}:水平方向(反射)".Fmt((int)MOVEMENT.VERTICAL_REFLECT),
                "*   {0}:十字(反射)".Fmt((int)MOVEMENT.CROSS_REFLECT),
                "*   {0}:斜め(反射)".Fmt((int)MOVEMENT.SLANT_REFLECT),
                "*   {0}:左".Fmt((int)MOVEMENT.LEFT),
                "*   {0}:右".Fmt((int)MOVEMENT.RIGHT),
                "*   {0}:上".Fmt((int)MOVEMENT.UP),
                "*   {0}:下".Fmt((int)MOVEMENT.DOWN),
                "*   {0}:水平".Fmt((int)MOVEMENT.HORIZONTAL),
                "*   {0}:垂直".Fmt((int)MOVEMENT.VERTICAL),
                "*   {0}:十字".Fmt((int)MOVEMENT.CROSS),
                "*   {0}:斜め".Fmt((int)MOVEMENT.SLANT),
                "*   {0}:ランダム".Fmt((int)MOVEMENT.RANDOM),
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
                            Name = "カマキリ大",
                            Movement = MOVEMENT.STATIONARY,
                            UnitImageFilePath = @".\MusExcResorce\01_01_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "飛カマキリ小(レア)",
                            Movement = MOVEMENT.UP,
                            AmountOfMovement = 5,
                            UnitImageFilePath = @".\MusExcResorce\01_01_unit02.gif",
                            Appearance = 1,
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
                            UnitImageFilePath = @".\MusExcResorce\01_02_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "飛セミ小(レア)",
                            Movement = MOVEMENT.HORIZONTAL,
                            AmountOfMovement = 5,
                            UnitImageFilePath = @".\MusExcResorce\01_02_unit02.gif",
                            Appearance = 1,
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
                            Name = "吸水トンボ大",
                            Movement = MOVEMENT.STATIONARY,
                            UnitImageFilePath = @".\MusExcResorce\01_03_unit01.gif",
                            Appearance = 100,
                        },
                        new MusExcQuestionDefUnit
                        {
                            Name = "吸水トンボ小(レア)",
                            Movement = MOVEMENT.STATIONARY,
                            UnitImageFilePath = @".\MusExcResorce\01_03_unit02.gif",
                            Appearance = 1,
                        },
                    },
            });

        }
    }
}
