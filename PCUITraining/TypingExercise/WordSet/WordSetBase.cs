using Common.Utilities;
using System.Collections.Generic;
using System.Linq;
using TypingExercise.Interfaces;

namespace TypingExercise.WordSet
{
    /// <summary>
    /// 単語セットの基底クラス.
    /// </summary>
    public abstract class WordSetBase
    {
        /// <summary>
        /// 単語リスト.
        /// </summary>
        protected List<WordBase> WordList { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public WordSetBase()
        {
            this.WordList = new List<WordBase>();
        }

        /// <summary>
        /// セット名を返す.
        /// </summary>
        public abstract string GetName();

        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <returns>成否</returns>
        public abstract bool LoadList();

        /// <summary>
        /// Web検索キーワードを生成する.
        /// </summary>
        /// <returns></returns>
        public abstract string CreateWebKeyWord(string word);

        /// <summary>
        /// 新たなゲーム用リストを作成して返す.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual List<WordBase> CreateNewGameList(int length = 0)
        {
            var newlist = WordList
                .OrderBy(a => UtilRandom.Next(WordList.Count))
                .ToList();

            if ((0 < length) && (length < newlist.Count))
            {
                // 切り詰める必要がある場合は切り詰める.
                return newlist.GetRange(0, length);
            }

            return newlist;
        }

        /// <summary>
        /// 単語の入力結果表示ダイアログ
        /// </summary>
        /// <returns>結果表示ダイアログ</returns>
        public abstract IResultWordDlg GetWordResultDlg();

        /// <summary>
        /// 総合結果表示ダイアログ
        /// </summary>
        /// <returns>結果表示ダイアログ</returns>
        public abstract IResultSetDlg GetSetResultDlg();
    }
}
