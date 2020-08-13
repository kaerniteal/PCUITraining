using Common.Extentions;
using Common.Web;
using PCUITCommon;
using PCUITCommon.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace TextInputExercise.TextSet.AnimeTitleSet.Naruto
{
    /// <summary>
    /// ナルト－アニメのサブタイトルリスト
    /// </summary>
    public static class AnimeTitleListNaruto
    {
        /// <summary>
        /// タイトルリスト.
        /// </summary>
        private static List<AnimeTitleSetTextNaruto> TitleList = null;


        /// <summary>
        /// タイトルリストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<AnimeTitleSetTextNaruto> GetNarutoTitleList()
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
                // WebのWikiからロード.
                var wc = PCUIT.CreateWebClient();
                var fromWiki = new AnimeTitleListNarutoFromWiki(wc);
                TitleList = fromWiki.GetPocketMonsterList();

                // Webから取得できた場合.
                if (0 < TitleList.Count)
                {
                    // ファイルに保存しておく.
                    var toFile = new AnimeTitleListNarutoFromFile
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
                TitleList = AnimeTitleListNarutoFromFile.Load();
            }

            return TitleList;
        }



        /// <summary>
        /// Wikiのアニメのサブタイトル一覧から一覧を取得する.
        /// </summary>

        public class AnimeTitleListNarutoFromWiki : HtmlAnalizerBase
        {
            /// <summary>
            /// WikiのUrl
            /// </summary>
            private static readonly string WikiUrl = @"https://ja.wikipedia.org/wiki/NARUTO_-ナルト-_(アニメ)";

            /// <summary>
            /// リストを格納する.
            /// </summary>
            private List<AnimeTitleSetTextNaruto> TitleWikiList { get; set; }

            /// <summary>
            /// 「第○話」行正規表現パターン.
            /// </summary>
            private Regex EpisodeLinRegex { get; set; }

            /// <summary>
            /// タイトル行正規表現パターン.
            /// </summary>
            private Regex TitleLinRegex { get; set; }

            /// <summary>
            /// フックしている話数.
            /// </summary>
            private string HookEpisode { get; set; }


            /// <summary>
            /// コンストラクタ.
            /// </summary>
            /// <param name="wc">WebClient</param>

            public AnimeTitleListNarutoFromWiki(WebClient wc) : base(wc)
            {
                this.TitleWikiList = new List<AnimeTitleSetTextNaruto>();

                this.EpisodeLinRegex = new Regex("^<td>[0-9]{1,3}</td>", RegexOptions.Compiled);
                this.TitleLinRegex = new Regex("^<td colspan=\"2\">.*</td>", RegexOptions.Compiled);

                this.HookEpisode = string.Empty;
            }

            /// <summary>
            /// リストを取得する.
            /// </summary>
            /// <returns>リスト</returns>
            public List<AnimeTitleSetTextNaruto> GetPocketMonsterList()
            {
                this.Url(WikiUrl);
                return this.TitleWikiList;
            }

            /// <summary>
            /// 行解析処理.
            /// </summary>
            /// <param name="line">行</param>

            protected override void LineAnalize(string line)
            {
                // 第○話に一致する行かどうか.
                if (this.EpisodeLinRegex.IsMatch(line))
                {
                    // 一致する場合エピソードを格納しておく.
                    this.HookEpisode = line.Right("<td>").Left("</td>");
                    return;
                }

                // 話数が格納されている状態で、
                // タイトル行に一致する行の場合.
                if (!this.HookEpisode.IsEmpty() &&
                    this.TitleLinRegex.IsMatch(line))
                {
                    var title = line.Right("<td colspan=\"2\">").Left("</td>");

                    // 例外対応1
                    title = Regex.Replace(title, @"<style.*?</style>", @"");

                    // 例外対応2
                    title = Regex.Replace(title, @"\[.*?\]", @"");

                    // タグのサプレス.
                    title = Regex.Replace(title, @"<.*?>", @"");

                    // フリガナのサプレス
                    title = Regex.Replace(title, @"（.*?）", @"");

                    // 例外の例外対応
                    title = title.Replace("♥", "-");

                    // 最後に確保したEpisodeと組み合わせてレコードを生成.
                    var text = new AnimeTitleSetTextNaruto(
                        this.HookEpisode.ToInt(),
                        title);

                    this.TitleWikiList.Add(text);

                    // Episodeは他の要素とペアリングされないように潰しておく.
                    this.HookEpisode = string.Empty;
                }
            }
        }

        /// <summary>
        /// ファイルとの入出力を行う.
        /// </summary>
        public class AnimeTitleListNarutoFromFile
        {
            /// <summary>
            /// リソースファイル.
            /// </summary>
            private static readonly string FileName = @"NarutoTitle.list";

            /// <summary>
            /// タイトルリスト.
            /// </summary>
            public List<AnimeTitleSetTextNaruto> TitleFileList { get; set; }

            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public AnimeTitleListNarutoFromFile()
            {
                this.TitleFileList = new List<AnimeTitleSetTextNaruto>();
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
            public static List<AnimeTitleSetTextNaruto> Load()
            {
                var list = new AnimeTitleListNarutoFromFile();

                var filePath = GetFilePath();

                // ファイルの存在をチェックし、存在する場合のみ読み込む。
                if (File.Exists(filePath))
                {
                    try
                    {
                        list = filePath.JsonLoad<AnimeTitleListNarutoFromFile>();
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
                    this.JsonSave(filePath);
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
