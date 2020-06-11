using System.Windows.Forms;
using TypingExercise.Executors;

namespace TypingExercise.Interfaces
{
    /// <summary>
    /// 単語入力結果表示インタフェース
    /// </summary>
    public interface IResultWordDlg
    {
        /// <summary>
        /// 入力結果表示
        /// </summary>
        /// <param name="wordResult">単語入力結果</param>
        /// <returns>DialogResult</returns>
        DialogResult ShowWordResultDlg(WordResult wordResult);
    }
}
