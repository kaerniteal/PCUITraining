using Common.Extentions;
using MouseExercise.Configs;
using MouseExercise.MusExcSet;
using MouseExercise.MusExcSet.InsectCollectingSet;
using PCUITCommon.Views;
using System.Collections.Generic;

namespace MouseExercise
{
    /// <summary>
    /// マウスアプリ－メインクラス.
    /// </summary>
    public static class MusExc
    {
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
        public static bool Init()
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
