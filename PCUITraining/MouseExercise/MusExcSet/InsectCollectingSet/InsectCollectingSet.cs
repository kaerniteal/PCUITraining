using MouseExercise.Interfaces;
using PCUITCommon.Users;

namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    /// <summary>
    /// MusExcSet－昆虫採集
    /// </summary>
    public class InsectCollectingSet : MusExcSetBase
    {
        /// <summary>
        /// セット名.
        /// </summary>
        public static readonly string Name = @"InsectCollecting";


        /// <summary>
        /// セット名を返す.
        /// </summary>
        public override string GetGameName()
        {
            return Name;
        }

        /// <summary>
        /// 読み込み処理.
        /// </summary>
        /// <returns>成否</returns>
        public override bool LoadList()
        {
            var qList = InsectCollectingSetQuestionList.Load();
            this.QuestionList = qList.QuestionList;

            return true;
        }

        /// <summary>
        /// ゲームインスタンスを取得する.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        /// <returns>ゲームインスタンスインタフェース</returns>
        public override IMusExcGameInstance GetGameInstance(UserData userData)
        {
            return new InsectCollectingSetGameInstance(this, userData);
        }
    }
}
