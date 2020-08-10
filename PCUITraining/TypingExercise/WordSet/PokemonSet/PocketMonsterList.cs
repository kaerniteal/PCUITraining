using Common.Extentions;
using Common.Web;
using PCUITCommon;
using PCUITCommon.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケットモンスターリスト
    /// </summary>
    public static class PocketMonsterList
    {
        /// <summary>
        /// リソースファイル.
        /// </summary>
        private static readonly string FileName = @".\WordSet\PokemonSet\PocketMonsterList.txt";

        /// <summary>
        /// WikiのUrl
        /// </summary>
        private static readonly string WikiUrl = @"https://ja.wikipedia.org/wiki/全国ポケモン図鑑順のポケモン一覧";

        /// <summary>
        /// ポケモンリスト.
        /// </summary>
        private static List<PokemonSetWord> PockMonList = null;


        /// <summary>
        /// ポケモンリストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<PokemonSetWord> GetPockeMonList()
        {
            if (null == PockMonList)
            {
                if (PCUIT.Conf.EnableWeb)
                {
                    LoadListFromWiki();
                }

                if (null == PockMonList || PockMonList.Count <= 0)
                {
                    LoadListFromFile();
                }
            }

            return PockMonList;
        }

        /// <summary>
        /// ロード処理(ファイルから).
        /// </summary>
        /// <returns>ポケモンリスト</returns>
        private static void LoadListFromFile()
        {
            try
            {
                PockMonList = new List<PokemonSetWord>();

                var listFile = new StreamReader(FileName);

                var line = string.Empty;
                while ((line = listFile.ReadLine()) != null)
                {
                    var sep = line.IndexOf(",");
                    if (0 < sep)
                    {
                        var num = line.Substring(0, sep);
                        var word = line.Substring(sep + 1);
                        PockMonList.Add(new PokemonSetWord(num, word));
                    }
                    else
                    {
                        FormMessageBox.Show("ポケモンデータの読み取りに失敗しました\n{0}".Fmt(line));
                    }
                }

                listFile.Close();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("ポケモンリストの読み込みに失敗しました。\nfile:{0}".Fmt(FileName));
            }
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
                var fromWiki = new PocketMonsterListFromWiki(wc);
                PockMonList = fromWiki.GetPocketMonsterList();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("ポケモンリストの読み込みに失敗しました。\nfile:{0}".Fmt(WikiUrl));
            }
        }

        /// <summary>
        /// Wikiの全国ポケモン図鑑順のポケモン一覧から一覧を取得する.
        /// </summary>

        private class PocketMonsterListFromWiki : HtmlAnalizerBase
        {
            /// <summary>
            /// リストを格納する.
            /// </summary>
            private List<PokemonSetWord> PockMonList { get; set; }

            /// <summary>
            /// ポケモンNo.行正規表現パターン.
            /// </summary>
            private Regex NoLinRegex { get; set; }

            /// <summary>
            /// ポケモン名行正規表現パターン.
            /// </summary>
            private Regex NameLinRegex { get; set; }

            /// <summary>
            /// フックしているNo.
            /// </summary>
            private string HookNo { get; set; }


            /// <summary>
            /// コンストラクタ.
            /// </summary>
            /// <param name="wc">WebClient</param>

            public PocketMonsterListFromWiki(WebClient wc) : base(wc)
            {
                this.PockMonList = new List<PokemonSetWord>();
                this.HookNo = string.Empty;

                this.NoLinRegex = new Regex("^[0-9]{1,4}</td>$", RegexOptions.Compiled);
                this.NameLinRegex = new Regex("^.*</a>$", RegexOptions.Compiled);
            }

            /// <summary>
            /// リストを取得する.
            /// </summary>
            /// <returns>リスト</returns>
            public List<PokemonSetWord> GetPocketMonsterList()
            {
                this.Url(WikiUrl);

                return this.PockMonList;
            }

            /// <summary>
            /// 解析前処理.
            /// </summary>
            /// <param name="html">取得したHTML</param>
            /// <returns>解析に与えるHTML</returns>
            protected override string BeforeAnalize(string html)
            {
                // 行にバラす.
                return html.Replace(">", ">\n");
            }

            /// <summary>
            /// 行解析処理.
            /// </summary>
            /// <param name="line">行</param>
            protected override void LineAnalize(string line)
            {
                // ポケモンNo.に一致する行かどうか.
                if (this.NoLinRegex.IsMatch(line))
                {
                    // 一致する場合No.を格納しておく.
                    this.HookNo = line.Left("<");
                    return;
                }

                // ポケモンNo.が格納されている状態で、
                // ポケモン名に一致する行の場合.
                if (!this.HookNo.IsEmpty() && this.NameLinRegex.IsMatch(line))
                {
                    var name = line.Left("<");

                    // 最後に確保したNo.と組み合わせてレコードを生成.
                    var word = new PokemonSetWord(this.HookNo, name);
                    this.PockMonList.Add(word);

                    // No.は他の要素とペアリングされないように潰しておく.
                    this.HookNo = string.Empty;
                }
            }
        }
    }
}
