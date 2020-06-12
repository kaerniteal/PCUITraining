using System.Collections.Generic;
using System.Windows.Forms;
using TypingExercise.Executors;
using TypingExercise.WordSet;

namespace TypingExercise.Interfaces
{
    /// <summary>
    /// ゲームインスタンスインタフェース
    /// </summary>
    public interface ITypExcGameInstance
    {
        /// <summary>
        /// 新たな単語リストを作成して返す.
        /// </summary>
        /// <param name="length">リスト長</param>
        /// <returns>単語リスト</returns>
        List<WordBase> CreateNewWordList(int length);

        /// <summary>
        /// アルファベットを大文字で表示するかどうか.
        /// </summary>
        /// <returns>true:大文字 false：小文字</returns>
        bool ShowSpellUpper();

        /// <summary>
        /// Web検索キーワードを生成する.
        /// </summary>
        /// <returns>キーワード</returns>
        string CreateWebKeyWord(string word);

        /// <summary>
        /// 単語入力毎の結果を表示する.
        /// </summary>
        /// <param name="result">単語入力結果</param>

        void ShowWordResult(WordResult result);

        /// <summary>
        /// 実行結果を表示する.
        /// </summary>
        /// <param name="result">実行結果</param>
        /// <returns>表示結果</returns>
        DialogResult ShowSetResultDlg(SetResult result);
    }
}
