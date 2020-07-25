using System.Collections.Generic;
using System.Windows.Forms;
using TextInputExercise.Executors;
using TextInputExercise.TextSet;

namespace TextInputExercise.Interfaces
{
    /// <summary>
    /// ゲームインスタンスインタフェース
    /// </summary>
    public interface ITIExcGameInstance
    {
        /// <summary>
        /// 新たな文字列リストを作成して返す.
        /// </summary>
        /// <param name="length">リスト長</param>
        /// <returns>単語リスト</returns>
        List<TextBase> CreateNewTextList(int length);

        /// <summary>
        /// 共通設定を返す..
        /// </summary>
        /// <returns>共通設定eturns>
        TextConf GetTextConf();

        /// <summary>
        /// Web検索キーワードを生成する.
        /// </summary>
        /// <returns>キーワード</returns>
        string CreateWebKeyWord(string word);

        /// <summary>
        /// 文字列入力毎の結果を表示する.
        /// </summary>
        /// <param name="result">文字列入力結果</param>
        void ShowTextResult(TextResult result);

        /// <summary>
        /// 実行結果を表示する.
        /// </summary>
        /// <param name="result">実行結果</param>
        /// <returns>表示結果</returns>
        DialogResult ShowSetResultDlg(SetResult result);
    }
}
