using Common.DataIO;
using Common.Extentions;
using Common.Web;
using PCUITCommon;
using PCUITCommon.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace TextInputExercise.TextSet.AnimeTitleSet.CellsAtWork
{
    /// <summary>
    /// 働く細胞－アニメのサブタイトルリスト
    /// </summary>
    public static class AnimeTitleListCellsAtWork
    {
        /// <summary>
        /// タイトルリスト.
        /// </summary>
        private static List<AnimeTitleSetTextCellsAtWork> TitleList = null;


        /// <summary>
        /// タイトルリストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<AnimeTitleSetTextCellsAtWork> GetCellsAtWorkTitleList()
        {
            // ロード済みであればそれを返す.
            if (null != TitleList)
            {
                return TitleList;
            }

            //****************//
            // 未ロード時処理 //
            //****************//

            // Webが有効な場合は.
            if (PCUIT.Conf.EnableWeb)
            {
                // Webからロード.
                var wc = PCUIT.CreateWebClient();
                var fromWiki = new AnimeTitleListCellsAtWorkFromWeb(wc);
                TitleList = fromWiki.GetTitleList();

                // Webから取得できた場合.
                if (0 < TitleList.Count)
                {
                    // ファイルに保存しておく.
                    var toFile = new AnimeTitleListCellsAtWorkFromFile
                    {
                        TitleFileList = TitleList,
                    };
                    toFile.Save();
                }
            }

            // Webからダウンロードできなかった場合、
            // 最後にローカルに保存したファイルからロード.
            if (null == TitleList || TitleList.Count <= 0)
            {
                TitleList = AnimeTitleListCellsAtWorkFromFile.Load();
            }

            return TitleList;
        }



        /// <summary>
        /// Webからアニメのサブタイトル一覧をスクレイピングする.
        /// </summary>

        public class AnimeTitleListCellsAtWorkFromWeb : HtmlAnalizerBase
        {
            /// <summary>
            /// 取得元URL
            /// </summary>
            private static readonly string SorceURL = @"https://cal.syoboi.jp/tid/4961/subtitle";

            /// <summary>
            /// 目印の為の置き換え文字列.
            /// </summary>
            private static readonly string MarkStr = @"<caw data>";

            /// <summary>
            /// リストを格納する.
            /// </summary>
            private List<AnimeTitleSetTextCellsAtWork> TitleWebList { get; set; }

            /// <summary>
            /// タイトル行正規表現パターン.
            /// </summary>
            private Regex TitleLinRegex { get; set; }


            /// <summary>
            /// コンストラクタ.
            /// </summary>
            /// <param name="wc">WebClient</param>

            public AnimeTitleListCellsAtWorkFromWeb(WebClient wc) : base(wc)
            {
                this.TitleWebList = new List<AnimeTitleSetTextCellsAtWork>();

                this.TitleLinRegex = new Regex("^" + MarkStr, RegexOptions.Compiled);
            }

            /// <summary>
            /// リストを取得する.
            /// </summary>
            /// <returns>リスト</returns>
            public List<AnimeTitleSetTextCellsAtWork> GetTitleList()
            {
                this.Url(SorceURL);

                foreach (var ttl in this.TitleWebList)
                {
                    Console.WriteLine($"{ttl.GetEpisode()}:{ttl.Text}");
                }

                return this.TitleWebList;
            }

            /// <summary>
            /// 解析前処理.
            /// </summary>
            /// <param name="html">取得したHTML</param>
            /// <returns>解析に与えるHTML</returns>
            protected override string BeforeAnalize(string html)
            {
                return html
                    .Right("<!-- サブタイトル一覧 -->")
                    .Left("<!-- /サブタイトル一覧 -->")
                    .Replace("<tr><td align=\"right\">", "\n" + MarkStr);
            }

            /// <summary>
            /// 行解析処理.
            /// </summary>
            /// <param name="line">行</param>

            protected override void LineAnalize(string line)
            {
                // タイトル行に一致する行の場合.
                if (this.TitleLinRegex.IsMatch(line))
                {
                    var episode = line.Right(MarkStr).Left("</td><td>");
                    var title = line.Right("</td><td>").Left("</td></tr>");

                    // 最後に確保したEpisodeと組み合わせてレコードを生成.
                    var text = new AnimeTitleSetTextCellsAtWork(
                        episode.ToInt(),
                        title);

                    this.TitleWebList.Add(text);
                }
            }
        }

        /// <summary>
        /// ファイルとの入出力を行う.
        /// </summary>
        public class AnimeTitleListCellsAtWorkFromFile
        {
            /// <summary>
            /// リソースファイル.
            /// </summary>
            private static readonly string FileName = @"CellsAtWorkTitle.list";

            /// <summary>
            /// タイトルリスト.
            /// </summary>
            public List<AnimeTitleSetTextCellsAtWork> TitleFileList { get; set; }

            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public AnimeTitleListCellsAtWorkFromFile()
            {
                this.TitleFileList = new List<AnimeTitleSetTextCellsAtWork>();
            }

            /// <summary>
            /// ファイルパスを返す.
            /// </summary>
            /// <returns></returns>
            private static string GetFilePath()
            {
                return UserDataManager.RootPath + FileName;
            }

            /// <summary>
            /// ロード処理.
            /// </summary>
            /// <remarks>失敗時にはNULLを返す</remarks>
            /// <returns>正答テーブル</returns>
            public static List<AnimeTitleSetTextCellsAtWork> Load()
            {
                var list = new AnimeTitleListCellsAtWorkFromFile();

                var filePath = GetFilePath();

                // ファイルの存在をチェックし、存在する場合のみ読み込む。
                if (File.Exists(filePath))
                {
                    try
                    {
                        list = JsonIO<AnimeTitleListCellsAtWorkFromFile>.Load(filePath);
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessageBox(@"ファイル[{0}]の読み込みに失敗しました".Fmt(filePath));
                    }
                }

                return list.TitleFileList;
            }

            /// <summary>
            /// セーブ処理.
            /// </summary>
            public bool Save()
            {
                var filePath = GetFilePath();

                try
                {
                    JsonIO<AnimeTitleListCellsAtWorkFromFile>.Save(this, filePath);
                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox(@"ファイル[{0}]の保存に失敗しました".Fmt(filePath));
                    return false;
                }

                return true;
            }
        }
    }
}
