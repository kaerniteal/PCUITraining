using MouseExercise.MusExcSet;
using System.Windows.Forms;
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

        /// <summary>
        /// 結果を表示する.
        /// </summary>
        /// <param name="result">実行結果</param>
        /// <returns>ダイアログリザルト</returns>
        DialogResult ShowSetResultDlg(MusExcSharedDataResult result);

        /// <summary>
        /// ユーザー個別設定を取得する.
        /// </summary>
        /// <returns></returns>
        MusExcUserConf GetMusExcSetConf();
    }
}
