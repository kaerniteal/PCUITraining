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
        /// 設問定義リスト.
        /// </summary>
        public List<MusExcQuestionDef> QuestionList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public InsectCollectingSetQuestionList()
        {
            this.QuestionList = new List<MusExcQuestionDef>();

            {
                var sample = new MusExcQuestionDef
                {
                    Difficulty = DIFFICULTY.EASY,
                    UnitNum = 1,
                    MaxNum = 3,
                    Behavior = new List<BEHAVIOR> { BEHAVIOR.HORIZONTAL },
                    BgType = BG_TYPE.COLOR,
                    BgColorR = 70,
                    BgColorG = 71,
                    BgColorB = 71,
                    BgImageFilePath = @".\MusExcResorce\Bg\bg_image01.jpg",
                    BugImageFilePathList = new List<string>
                    {
                        @".\MusExcResorce\Units\unit_image01_01.gif",
                        @".\MusExcResorce\Units\unit_image02_01.gif",
                    },

                };

                this.QuestionList.Add(sample);
            }
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
                this.JsonSave(FileName);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox(@"ファイル[{0}]の保存に失敗しました".Fmt(FileName));
                return false;
            }

            return true;
        }
    }
}
