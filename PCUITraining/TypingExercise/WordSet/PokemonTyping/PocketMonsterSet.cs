using System.Linq;
using TypingExercise.Interfaces;

namespace TypingExercise.WordSet.PokemonTyping
{
    /// <summary>
    /// ワードセット－ポケモンタイピング
    /// </summary>
    public class PocketMonsterSet : WordSetBase
    {
        /// <summary>
        /// セット名.
        /// </summary>
        public static readonly string Name = @"PokemonTyping";


        /// <summary>
        /// セット名を返す.
        /// </summary>
        public override string GetName()
        {
            return Name;
        }

        /// <summary>
        /// Web検索キーワードを生成する.
        /// </summary>
        /// <returns></returns>
        public override string CreateWebKeyWord(string word)
        {
            var keyword = TypExc.Conf.AddWebImageSearchKeyword;
            return keyword + "+" + word;
        }

        /// <summary>
        /// 読み込み処理.
        /// </summary>
        /// <returns>成否</returns>
        public override bool LoadList()
        {
            this.WordList = PocketMonsterList.GetPockeMonList()
                .Select(pockemon => (WordBase)pockemon)
                .ToList();

            return true;
        }

        /// <summary>
        /// 単語の入力結果表示ダイアログ
        /// </summary>
        /// <param name="wordResult">単語の入力結果</param>
        /// <returns>結果表示ダイアログ</returns>
        public override IResultWordDlg GetWordResultDlg()
        {
            return new PocketMonsterResultWord();
        }

        /// <summary>
        /// 総合結果表示ダイアログ
        /// </summary>
        /// <returns>結果表示ダイアログ</returns>
        public override IResultSetDlg GetSetResultDlg()
        {
            return new PocketMonsterResultSet();
        }
    }
}
