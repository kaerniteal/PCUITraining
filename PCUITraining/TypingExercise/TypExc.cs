using Common.Extentions;
using PCUITCommon.Views;
using System.Collections.Generic;
using System.Windows.Forms;
using TypingExercise.Configs;
using TypingExercise.Definitions;
using TypingExercise.WordSet;
using TypingExercise.WordSet.PokemonSet;

namespace TypingExercise
{
    /// <summary>
    /// メインクラス.
    /// </summary>
    public class TypExc
    {
        /// <summary>
        /// 設定.
        /// </summary>
        public static TypExcConf Conf { get; set; }

        /// <summary>
        /// 正しい綴りテーブル.
        /// </summary>
        public static CorrectSpellingTable CorrectSpellingTable { get; private set; }

        /// <summary>
        /// ワードセットのリスト.
        /// </summary>
        public static List<WordSetBase> WordListList { get; set; }


        /// <summary>
        /// 初期化処理.
        /// </summary>
        /// <returns>成否</returns>
        public bool Init()
        {
            Conf = TypExcConf.Load();

            CorrectSpellingTable = CorrectSpellingTable.Load();
            if (null == CorrectSpellingTable)
            {
                return false;
            }

            // ワードセットのリストを生成.
            WordListList = new List<WordSetBase>
            {
                new PokemonSet(),
            };

            // ワードセットをロード.
            foreach (var set in WordListList)
            {
                if (!set.LoadList())
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// セットを取得する.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static WordSetBase GetWordList(string name)
        {
            var wordSet = WordListList
                .Find(list => name.Equals(list.GetGameName()));
            if (null == wordSet)
            {
                FormMessageBox.Show("[{0}]が見つかりません".Fmt(name));
            }

            return wordSet;
        }
    }
}
