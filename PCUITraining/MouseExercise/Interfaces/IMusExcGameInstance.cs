using MouseExercise.MusExcSet;
using static MouseExercise.Definitions.MusExcEnums;

namespace MouseExercise.Interfaces
{
    /// <summary>
    /// ゲームインスタンスインタフェース
    /// </summary>
    public interface IMusExcGameInstance
    {
        /// <summary>
        /// 新たな設問を取得する.
        /// </summary>
        /// <param name="difficulty">難易度</param>
        /// <returns></returns>
        MusExcQuestionDef GetQuestionDef(DIFFICULTY difficulty);
    }
}
