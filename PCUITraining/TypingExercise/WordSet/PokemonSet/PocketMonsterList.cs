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

namespace TypingExercise.WordSet.PokemonSet
{
    /// <summary>
    /// ポケットモンスターリスト
    /// </summary>
    public static class PocketMonsterList
    {
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
            // ロード済みであればそれを返す.
            if (null != PockMonList)
            {
                return PockMonList;
            }

            //****************//
            // 未ロード時処理 //
            //****************//

            // Webが有効な場合は.
            if (PCUIT.Conf.EnableWeb)
            {
                // WebのWikiからロード.
                var wc = PCUIT.CreateWebClient();
                var fromWiki = new PocketMonsterListFromWiki(wc);
                PockMonList = fromWiki.GetPocketMonsterList();

                // Webから取得できた場合.
                if (0 < PockMonList.Count)
                {
                    // ファイルに保存しておく.
                    var toFile = new PocketMonsterListFromFile
                    {
                        PockMonFileList = PockMonList,
                    };
                    toFile.Save();
                }
            }

            // Webからダウンロードできなかった場合、
            // 最後にローカルに保存したファイルからロード.
            if (null == PockMonList || PockMonList.Count <= 0)
            {
                //var fromFile = new PocketMonsterListFromFile();
                //PockMonList = fromFile.LoadListFromFile();
                PockMonList = PocketMonsterListFromFile.Load();
            }

            return PockMonList;
        }


        /// <summary>
        /// Wikiの全国ポケモン図鑑順のポケモン一覧から一覧を取得する.
        /// </summary>
        public class PocketMonsterListFromWiki : HtmlAnalizerBase
        {
            /// <summary>
            /// WikiのUrl
            /// </summary>
            private static readonly string WikiUrl = @"https://ja.wikipedia.org/wiki/全国ポケモン図鑑順のポケモン一覧";

            /// <summary>
            /// リストを格納する.
            /// </summary>
            private List<PokemonSetWord> PockMonWikiList { get; set; }

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
                this.PockMonWikiList = new List<PokemonSetWord>();
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

                return this.PockMonWikiList;
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
                    this.PockMonWikiList.Add(word);

                    // No.は他の要素とペアリングされないように潰しておく.
                    this.HookNo = string.Empty;
                }
            }
        }


        /// <summary>
        /// ローカルファイルとの入出力を行う.
        /// </summary>
        public class PocketMonsterListFromFile
        {
            /// <summary>
            /// リソースファイル.
            /// </summary>
            private static readonly string FileName = @"PocketMonster.list";

            /// <summary>
            /// ポケモンリスト.
            /// </summary>
            public List<PokemonSetWord> PockMonFileList { get; set; }


            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public PocketMonsterListFromFile()
            {
                this.PockMonFileList = new List<PokemonSetWord>();
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
            public static List<PokemonSetWord> Load()
            {
                var list = new PocketMonsterListFromFile();

                var filePath = GetFilePath();

                // ファイルの存在をチェックし、存在する場合のみ読み込む。
                if (File.Exists(filePath))
                {
                    try
                    {
                        list = JsonIO<PocketMonsterListFromFile>.Load(filePath);
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessageBox(@"ファイル[{0}]の読み込みに失敗しました".Fmt(filePath));
                    }
                }

                return list.PockMonFileList;
            }

            /// <summary>
            /// セーブ処理.
            /// </summary>
            public bool Save()
            {
                var filePath = GetFilePath();

                try
                {
                    JsonIO<PocketMonsterListFromFile>.Save(this, filePath);
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
