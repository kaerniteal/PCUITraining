using PCUITCommon.Users;
using System.Windows.Forms;
using TypingExercise.Executors;

namespace TypingExercise.Interfaces
{
    /// <summary>
    /// 総合結果表示インタフェース
    /// </summary>
    public interface IResultSetDlg
    {
        /// <summary>
        /// 総合結果表示
        /// </summary>
        /// <param name="setResult">総合結果</param>
        /// <param name="userData">結果の保存先</param>
        /// <returns>DialogResult</returns>
        DialogResult ShowSetResultDlg(SetResult setResult, UserData userData);
    }
}
