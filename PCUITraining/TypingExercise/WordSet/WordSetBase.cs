using Common.Utilities;
using PCUITCommon.Users;
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
        public abstract string GetGameName();

        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <returns>成否</returns>
        public abstract bool LoadList();

        /// <summary>
        /// 新たな単語リストを作成して返す.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual List<WordBase> CreateNewWordList(int length = 0)
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
        /// ゲームインスタンスを取得する.
        /// </summary>
        /// <param name="userData">ユーザーデータ</param>
        /// <returns>ゲームインスタンスインタフェース</returns>
        public abstract ITypExcGameInstance GetGameInstance(UserData userData);
    }
}
