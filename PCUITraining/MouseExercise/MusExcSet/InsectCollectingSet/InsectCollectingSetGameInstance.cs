using Common.Utilities;
using MouseExercise.Interfaces;
using PCUITCommon.Users;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    /// <summary>
    /// 昆虫採集セットゲームインスタンス.
    /// </summary>
    public class InsectCollectingSetGameInstance : IMusExcGameInstance
    {
        /// <summary>
        /// 昆虫採集セット.
        /// </summary>
        private InsectCollectingSet ICSet { get; set; }

        /// <summary>
        /// ユーザーデータ.
        /// </summary>
        private UserData UserData { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="icSet">昆虫採集セット</param>
        /// <param name="userData">ユーザーデータ</param>
        public InsectCollectingSetGameInstance(InsectCollectingSet icSet, UserData userData)
        {
            this.ICSet = icSet;
            this.UserData = userData;
        }

        /// <summary>
        /// 新たな設問を取得する.
        /// </summary>
        /// <param name="difficulty">難易度</param>
        /// <returns></returns>
        public MusExcQuestionDef GetQuestionDef(DIFFICULTY difficulty)
        {
            var list = this.ICSet.GetQuestionDefList(difficulty);
            if (list.Count <= 0)
            {
                list = this.ICSet.GetQuestionDefList(DIFFICULTY.NON); ;
            }

            var index = UtilRandom.Next(list.Count);
            return list[index];
        }

    }
}
