using MouseExercise.Interfaces;
using PCUITCommon.Users;
using System.Collections.Generic;
using System.Linq;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.MusExcSet
{
    /// <summary>
    /// マウスクリックゲームの基底クラス.
    /// </summary>
    public abstract class MusExcSetBase
    {
        /// <summary>
        /// 設問リスト.
        /// </summary>
        protected List<MusExcQuestionDef> QuestionList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MusExcSetBase()
        {
            this.QuestionList = new List<MusExcQuestionDef>();
        }

        /// <summary>
        /// セット名を返す.
        /// </summary>
        public abstract string GetGameName();

        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <returns>成否</returns>
        public abstract bool LoadList();

        /// <summary>
        /// 難易度でフィルタした設問リストを返す.
        /// </summary>
        /// <param name="difficulty">難易度</param>
        /// <returns>設問リスト</returns>
        public virtual List<MusExcQuestionDef> GetQuestionDefList(DIFFICULTY difficulty)
        {
            return this.QuestionList
                .Where(q => q.Difficulty == difficulty || DIFFICULTY.NON == difficulty)
                .ToList();
        }

        /// <summary>
        /// ゲームインスタンスを取得する.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        /// <returns>ゲームインスタンスインタフェース</returns>
        public abstract IMusExcGameInstance GetGameInstance(UserData userData);
    }
}
