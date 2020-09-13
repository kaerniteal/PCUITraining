using Common.Extentions;
using Common.Values;
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
        public static Result Init()
        {
            Conf = TIExcConf.Load();

            // テキストセットのリストを生成.
            TextSetList = new List<TextSetBase>
            {
                new AnimeTitleSet(),
            };

            // テキストセットをロード.
            foreach (var set in TextSetList)
            {
                var result = set.LoadList();
                if (result.IsNG)
                {
                    return Result.NG($"テキストセットのロードに失敗しました。\n{set.GetGameName()}", result);
                }
            }

            return Result.OK();
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
