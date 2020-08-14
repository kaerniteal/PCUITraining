using Common.Extentions;
using PCUITCommon.Views;
using System.Collections.Generic;
using TextInputExercise.Configs;
using TextInputExercise.TextSet;
using TextInputExercise.TextSet.AnimeTitleSet;

namespace TextInputExercise
{
    /// <summary>
    /// テキスト入力アプリ－メインクラス.
    /// </summary>
    public static class TIExc
    {
        /// <summary>
        /// 設定.
        /// </summary>
        public static TIExcConf Conf { get; set; }

        /// <summary>
        /// テキストセットのリスト.
        /// </summary>
        public static List<TextSetBase> TextSetList { get; set; }


        /// <summary>
        /// 初期化処理.
        /// </summary>
        /// <returns>成否</returns>
        public static bool Init()
        {
            Conf = TIExcConf.Load();

            // テキストセットのリストを生成.
            TextSetList = new List<TextSetBase>
            {
//                new PokeaniSet(),
                new AnimeTitleSet(),
            };

            // テキストセットをロード.
            foreach (var set in TextSetList)
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
        public static TextSetBase GetTextSet(string name)
        {
            var wordSet = TextSetList
                .Find(set => name.Equals(set.GetGameName()));
            if (null == wordSet)
            {
                FormMessageBox.Show("[{0}]が見つかりません".Fmt(name));
            }

            return wordSet;
        }
    }
}
