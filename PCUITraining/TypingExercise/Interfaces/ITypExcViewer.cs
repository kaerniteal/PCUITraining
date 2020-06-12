using PCUITCommon.Datas;
using System.Collections.Generic;
using TypingExercise.Definitions;
using TypingExercise.Executors;

namespace TypingExercise.Interfaces
{
    /// <summary>
    /// 表示インタフェース
    /// </summary>
    public interface ITypExcViewer
    {
        /// <summary>
        /// 新しい入力対象単語をセットする.
        /// </summary>
        /// <param name="word">入力対象文字列</param>
        /// <returns>関連するイメージを抱えるストア</returns>
        ImageStore SetNewWord(string word);

        /// <summary>
        /// Key入力に対する結果を通知.
        /// </summary>
        /// <param name="inputed">入力済み文字列</param>
        /// <param name="current">入力中文字列</param>
        /// <param name="spellings">次の入力文字の綴りリスト</param>
        /// <param name="missTypes">ミスタイプ文字</param>
        void ShowKeyResult(string inputed, string current, List<CorrectSpelling> spellings, string missTypes);

        /// <summary>
        /// 単語入力毎の結果を通知.
        /// </summary>
        void ShowWordResult(WordResult result);

        /// <summary>
        /// 実行後の総合結果を通知.
        /// </summary>
        /// <param name="result">実行結果</param>
        void ShowSetResult(SetResult result);
    }
}
