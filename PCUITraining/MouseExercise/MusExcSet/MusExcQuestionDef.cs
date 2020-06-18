using System.Collections.Generic;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.MusExcSet
{
    /// <summary>
    /// MusExc設問定義クラス.
    /// </summary>
    public class MusExcQuestionDef
    {
        /// <summary>
        /// 難易度
        /// </summary>
        public DIFFICULTY Difficulty { get; set; }

        /// <summary>
        /// 同時描画ユニット数
        /// </summary>
        public int UnitNum { get; set; }

        /// <summary>
        /// 生成ユニット最大数
        /// </summary>
        public int MaxNum { get; set; }

        /// <summary>
        /// 背景タイプ.
        /// </summary>
        public BG_TYPE BgType { get; set; }

        /// <summary>
        /// 背景色(R)
        /// </summary>
        public int BgColorR { get; set; }

        /// <summary>
        /// 背景色(G)
        /// </summary>
        public int BgColorG { get; set; }

        /// <summary>
        /// 背景色(B)
        /// </summary>
        public int BgColorB { get; set; }

        /// <summary>
        /// 背景画像ファイルパス.
        /// </summary>
        public string BgImageFilePath { get; set; }

        /// <summary>
        /// ユニットリスト.
        /// </summary>
        public List<MusExcQuestionDefUnit> UnitList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcQuestionDef()
        {
            this.Difficulty = DIFFICULTY.VERY_EASY;
            this.UnitNum = 1;
            this.MaxNum = 1;
            this.BgType = BG_TYPE.COLOR;
            this.BgColorR = 0;
            this.BgColorG = 0;
            this.BgColorB = 0;
            this.BgImageFilePath = string.Empty;
            this.UnitList = new List<MusExcQuestionDefUnit>();
        }
    }
}
