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
                var wc = PCUIT.CreateWebClient();
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
            /// シリーズ行正規表現パターン.
            /// </summary>
            private Regex SeriesLinRegex { get; set; }

            /// <summary>
            /// ○○編行正規表現パターン.
            /// </summary>
            private Regex VolumeLinRegex { get; set; }

            /// <summary>
            /// 「第○話」行正規表現パターン.
            /// </summary>
            private Regex EpisodeLinRegex { get; set; }

            /// <summary>
            /// トータル「第○話」行正規表現パターン.
            /// </summary>
            private Regex TotalLinRegex { get; set; }

            /// <summary>
            /// タイトル行正規表現パターン.
            /// </summary>
            private Regex TitleLinRegex { get; set; }

            /// <summary>
            /// フックしているシリーズ.
            /// </summary>
            private string HookSeries { get; set; }

            /// <summary>
            /// フックしている○○編
            /// </summary>
            private string HookVolume { get; set; }

            /// <summary>
            /// フックしている話数.
            /// </summary>
            private string HookEpisode { get; set; }

            /// <summary>
            /// フックしているトータル話数.
            /// </summary>
            private string HookTotal { get; set; }


            /// <summary>
            /// コンストラクタ.
            /// </summary>
            /// <param name="wc">WebClient</param>

            public PocketMonsterTitleListFromWiki(WebClient wc) : base(wc)
            {
                this.TitleList = new List<PokeaniSetText>();

                this.SeriesLinRegex = new Regex("^<h2><span id=\"", RegexOptions.Compiled);
                this.VolumeLinRegex = new Regex("^<h[3-4]><span id=\"", RegexOptions.Compiled);
                this.EpisodeLinRegex = new Regex("^<td><a href=\"/wiki/.*\" title=\".*\">.*</a>", RegexOptions.Compiled);
                this.TotalLinRegex = new Regex("^<td>第[0-9]{1,4}話", RegexOptions.Compiled);
                this.TitleLinRegex = new Regex("^<td class=\"l\">.*", RegexOptions.Compiled);

                this.HookSeries = string.Empty;
                this.HookVolume = string.Empty;
                this.HookEpisode = string.Empty;
                this.HookTotal = string.Empty;
            }

            /// <summary>
            /// リストを取得する.
            /// </summary>
            /// <returns>リスト</returns>
            public List<PokeaniSetText> GetPocketMonsterList()
            {
                this.Url(WikiUrl);

                foreach (var title in this.TitleList)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}".Fmt(
                        title.Series,
                        title.Volume,
                        title.Episode,
                        title.Total,
                        title.Text));
                }

                return this.TitleList;
            }

            /// <summary>
            /// 行解析処理.
            /// </summary>
            /// <param name="line">行</param>

            protected override void LineAnalize(string line)
            {
                // シリーズに一致する行かどうか.
                if (this.SeriesLinRegex.IsMatch(line))
                {
                    // 一致する場合シリーズを格納しておく.
                    this.HookSeries = line.Right("\"").Left("\"");
                    // シリーズ変わりでクリアする.
                    this.HookVolume = string.Empty;
                    this.HookEpisode = string.Empty;
                    this.HookTotal = string.Empty;
                    return;
                }

                // ○○編に一致する行かどうか.
                if (this.VolumeLinRegex.IsMatch(line))
                {
                    // 一致する場合○○編を格納しておく.
                    this.HookVolume = line.Right("\"").Left("\"");
                    return;
                }

                // 第○話に一致する行かどうか.
                if (this.EpisodeLinRegex.IsMatch(line))
                {
                    // 一致する場合エピソードを格納しておく.
                    this.HookEpisode = line.Right("title=\"").Left("\">");
                    return;
                }

                // トータル第○話に一致する行かどうか.
                if (this.TotalLinRegex.IsMatch(line))
                {
                    // 一致する場合トータル話数を格納しておく.
                    this.HookTotal = line.Right("第").Left("話");
                    return;
                }

                // 話数とトータル話数が格納されている状態で、
                // タイトル行に一致する行の場合.
                if (!this.HookEpisode.IsEmpty() &&
                    !this.HookTotal.IsEmpty() &&
                    this.TitleLinRegex.IsMatch(line))
                {
                    var title = line.Right(">");

                    // 改行を含むケース対応.
                    if (title.Contains("<br />"))
                    {
                        title = title.Left("<br />");
                    }

                    // 最後に確保したEpisodeと組み合わせてレコードを生成.
                    var text = new PokeaniSetText(
                        this.HookTotal.ToInt(),
                        this.HookSeries,
                        this.HookVolume,
                        this.HookEpisode,
                        title);

                    this.TitleList.Add(text);

                    // Episodeは他の要素とペアリングされないように潰しておく.
                    this.HookEpisode = string.Empty;
                    this.HookTotal = string.Empty;
                }
            }
        }
    }
}
