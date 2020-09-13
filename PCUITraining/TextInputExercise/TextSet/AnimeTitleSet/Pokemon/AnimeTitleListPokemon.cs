using Common.DataIO;
using Common.Extentions;
using Common.Values;
using Common.Web;
using PCUITCommon;
using PCUITCommon.Users;
using PCUITCommon.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace TextInputExercise.TextSet.AnimeTitleSet.Pokemon
{
    /// <summary>
    /// ポケットモンスター－アニメのサブタイトルリスト
    /// </summary>
    public static class AnimeTitleListPokemon
    {
        /// <summary>
        /// タイトルリスト.
        /// </summary>
        private static List<AnimeTitleSetTextPokemon> TitleList = null;


        /// <summary>
        /// タイトルリストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<AnimeTitleSetTextPokemon> GetPokemonTitleList()
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
                var fromWiki = new AnimeTitleListPokemonFromWeb(wc);
                TitleList = fromWiki.GetTitleList();

                // Webから取得できた場合.
                if (0 < TitleList.Count)
                {
                    // ファイルに保存しておく.
                    var toFile = new AnimeTitleListPokemonFromFile
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
                TitleList = AnimeTitleListPokemonFromFile.Load();
            }

            return TitleList;
        }


        /// <summary>
        /// Webからアニメのサブタイトル一覧をスクレイピングする.
        /// </summary>

        public class AnimeTitleListPokemonFromWeb : HtmlAnalizerBase
        {
            /// <summary>
            /// 取得元URL
            /// </summary>
            private static readonly string SorceURL = @"https://wiki.xn--rckteqa2e.com/wiki/アニメのサブタイトル一覧";

            /// <summary>
            /// リストを格納する.
            /// </summary>
            private List<AnimeTitleSetTextPokemon> TitleWebList { get; set; }

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

            public AnimeTitleListPokemonFromWeb(WebClient wc) : base(wc)
            {
                this.TitleWebList = new List<AnimeTitleSetTextPokemon>();

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
            public List<AnimeTitleSetTextPokemon> GetTitleList()
            {
                var res = this.Url(SorceURL);
                if (res.IsNG)
                {
                    FormMessageBox.Show($@"[ポケットモンスター]のタイトルリストの取得に失敗しました。\n{res.Message}");
                }

                return this.TitleWebList;
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
                    var text = new AnimeTitleSetTextPokemon(
                        this.HookTotal.ToInt(),
                        this.HookSeries,
                        this.HookVolume,
                        this.HookEpisode,
                        title);

                    this.TitleWebList.Add(text);

                    // Episodeは他の要素とペアリングされないように潰しておく.
                    this.HookEpisode = string.Empty;
                    this.HookTotal = string.Empty;
                }
            }
        }

        /// <summary>
        /// ファイルとの入出力を行う.
        /// </summary>
        public class AnimeTitleListPokemonFromFile
        {
            /// <summary>
            /// リソースファイル.
            /// </summary>
            private static readonly string FileName = @"PokemonTitle.list";

            /// <summary>
            /// タイトルリスト.
            /// </summary>
            public List<AnimeTitleSetTextPokemon> TitleFileList { get; set; }

            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public AnimeTitleListPokemonFromFile()
            {
                this.TitleFileList = new List<AnimeTitleSetTextPokemon>();
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
            public static List<AnimeTitleSetTextPokemon> Load()
            {
                var list = new AnimeTitleListPokemonFromFile();

                var filePath = GetFilePath();

                // ファイルの存在をチェックし、存在する場合のみ読み込む。
                if (File.Exists(filePath))
                {
                    try
                    {
                        list = JsonIO.Load<AnimeTitleListPokemonFromFile>(filePath);
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
            /// <returns>成否</returns>
            public Result Save()
            {
                var filePath = GetFilePath();

                try
                {
                    JsonIO.Save(this, filePath);
                }
                catch (Exception ex)
                {
                    return Result.NG($"ファイルの保存に失敗しました\n{filePath}", ex);
                }

                return Result.OK();
            }
        }
    }
}
