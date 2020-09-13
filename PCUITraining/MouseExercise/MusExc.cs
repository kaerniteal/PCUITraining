using Common.Extentions;
using Common.Logger;
using Common.Values;
using MouseExercise.Configs;
using MouseExercise.MusExcSet;
using MouseExercise.MusExcSet.InsectCollectingSet;
using PCUITCommon.Views;
using System.Collections.Generic;
using System.Reflection;

namespace MouseExercise
{
    /// <summary>
    /// マウスアプリ－メインクラス.
    /// </summary>
    public static class MusExc
    {
        /// <summary>
        /// ログ.
        /// </summary>
        private static Log4netLogger Log = new Log4netLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 設定.
        /// </summary>
        public static MusExcConf Conf { get; set; }

        /// <summary>
        /// マウスクリックゲームセットのリスト.
        /// </summary>
        public static List<MusExcSetBase> MusExcSetList { get; set; }


        /// <summary>
        /// 初期化処理.
        /// </summary>
        /// <returns>成否</returns>
        public static Result Init()
        {
            Conf = MusExcConf.Load();

            // ワードセットのリストを生成.
            MusExcSetList = new List<MusExcSetBase>
            {
                new InsectCollectingSet(),
            };

            // ワードセットをロード.
            foreach (var set in MusExcSetList)
            {
                var result = set.LoadList();
                if (result.IsNG)
                {
                    var message = $"ワードセットのロードに失敗しました。";
                    Log.Error(message);
                    return Result.NG(message, result);
                }
            }

            return Result.OK();
        }

        /// <summary>
        /// セットを取得する.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MusExcSetBase GetMusExcSet(string name)
        {
            var wordSet = MusExcSetList
                .Find(set => name.Equals(set.GetGameName()));
            if (null == wordSet)
            {
                FormMessageBox.Show("[{0}]が見つかりません".Fmt(name));
            }

            return wordSet;
        }
    }
}
