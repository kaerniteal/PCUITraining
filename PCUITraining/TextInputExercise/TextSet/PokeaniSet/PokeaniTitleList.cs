using Common.Extentions;
using Common.Web;
using PCUITCommon;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace TextInputExercise.TextSet.PokeaniSet
{
    /// <summary>
    /// ポケットモンスターアニメのサブタイトルリスト
    /// </summary>
    public static class PokeaniTitleList
    {
        /// <summary>
        /// WikiのUrl
        /// </summary>
        private static readonly string WikiUrl = @"https://wiki.xn--rckteqa2e.com/wiki/アニメのサブタイトル一覧";

        /// <summary>
        /// ポケモンタイトルリスト.
        /// </summary>
        private static List<PokeaniSetText> TitleList = null;


        /// <summary>
        /// タイトルリストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<PokeaniSetText> GetPokemonTitleList()
        {
            if (null == TitleList)
            {
                LoadListFromWiki();
            }

            return TitleList;
        }

        /// <summary>
        /// ロード処理(WebのWikiから).
        /// </summary>
        /// <returns>ポケモンリスト</returns>
        private static void LoadListFromWiki()
        {
            try
            {
                var wc = PCUIT.GetWebClient();
                var fromWiki = new PocketMonsterTitleListFromWiki(wc);
                TitleList = fromWiki.GetPocketMonsterList();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("ポケモンタイトルリストの読み込みに失敗しました。\nfile:{0}".Fmt(WikiUrl));
            }
        }

        /// <summary>
        /// Wikiのアニメのサブタイトル一覧から一覧を取得する.
        /// </summary>

        private class PocketMonsterTitleListFromWiki : HtmlAnalizerBase
        {
            /// <summary>
            /// リストを格納する.
            /// </summary>
            private List<PokeaniSetText> TitleList { get; set; }

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

            public PocketMonsterTitleListFromWiki(WebClient wc) : base(wc)
            {
                this.TitleList = new List<PokeaniSetText>();
                this.HookEpisode = string.Empty;

                this.EpisodeLinRegex = new Regex("^<td><a href=\"/wiki/.*\" title=\".*\">.*</a>", RegexOptions.Compiled);
                this.TitleLinRegex = new Regex("^<td class=\"l\">.*", RegexOptions.Compiled);
            }

            /// <summary>
            /// リストを取得する.
            /// </summary>
            /// <returns>リスト</returns>
            public List<PokeaniSetText> GetPocketMonsterList()
            {
                this.Url(WikiUrl);

                return this.TitleList;
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
                    this.HookEpisode = line.Right("title=\"").Left("\">");
                    return;
                }

                // ポケモンNo.が格納されている状態で、
                // ポケモン名に一致する行の場合.
                if (!this.HookEpisode.IsEmpty() && this.TitleLinRegex.IsMatch(line))
                {
                    var title = line.Right(">");

                    // 最後に確保したEpisodeと組み合わせてレコードを生成.
                    var text = new PokeaniSetText(this.TitleList.Count, this.HookEpisode, title);
                    this.TitleList.Add(text);

                    // Episodeは他の要素とペアリングされないように潰しておく.
                    this.HookEpisode = string.Empty;
                }
            }
        }
    }
}
