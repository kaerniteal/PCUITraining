using System;
using System.Collections.Generic;
using System.Linq;

namespace MouseExercise.MusExcSet
{
    /// <summary>
    /// 実行結果クラス.
    /// </summary>
    public class MusExcSharedDataResult
    {
        /// <summary>
        /// クリックしたユニットリスト
        /// </summary>
        public List<MusExcQuestionDefUnit> DeadUnitList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcSharedDataResult()
        {
            this.DeadUnitList = new List<MusExcQuestionDefUnit>();
        }

        /// <summary>
        /// 結果一覧を返す.
        /// </summary>
        /// <returns>結果一覧</returns>
        public List<MusExcSharedDataResultRecord> GetResultList()
        {
            return this.DeadUnitList
                .ToLookup(unit => unit.Name)
                .Select(chank => new MusExcSharedDataResultRecord()
                {
                    UnitName = chank.Key,
                    ClickedCount = chank.Count(),
                    DefUnit = chank.ElementAt(0),
                })
                .ToList();
        }
    }
}
