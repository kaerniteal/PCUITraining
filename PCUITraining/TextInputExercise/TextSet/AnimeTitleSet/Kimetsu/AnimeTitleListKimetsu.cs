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

namespace TextInputExercise.TextSet.AnimeTitleSet.Kimetsu
{
    /// <summary>
    /// 鬼滅の刃－アニメのサブタイトルリスト
    /// </summary>
    public static class AnimeTitleListKimetsu
    {
        /// <summary>
        /// タイトルリスト.
        /// </summary>
        private static List<AnimeTitleSetTextKimetsu> TitleList = null;


        /// <summary>
        /// タイトルリストを取得する.
        /// </summary>
        /// <returns></returns>
        public static List<AnimeTitleSetTextKimetsu> GetKimetsuTitleList()
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
                var fromWiki = new AnimeTitleListKimetsuFromWeb(wc);
                TitleList = fromWiki.GetTitleList();

                // Webから取得できた場合.
                if (0 < TitleList.Count)
                {
                    // ファイルに保存しておく.
                    var toFile = new AnimeTitleListKimetsuFromFile
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
                TitleList = AnimeTitleListKimetsuFromFile.Load();
            }

            return TitleList;
        }



        /// <summary>
        /// Webからアニメのサブタイトル一覧をスクレイピングする.
        /// </summary>

        public class AnimeTitleListKimetsuFromWeb : HtmlAnalizerBase
        {
            /// <summary>
            /// 取得元URL
            /// </summary>
            private static readonly string SorceURL = @"https://manga-tei.com/kimetsu-no-yaiba-title/";

            /// <summary>
            /// リストを格納する.
            /// </summary>
            private List<AnimeTitleSetTextKimetsu> TitleWebList { get; set; }

            /// <summary>
            /// タイトル行正規表現パターン.
            /// </summary>
            private Regex TitleLinRegex { get; set; }


            /// <summary>
            /// コンストラクタ.
            /// </summary>
            /// <param name="wc">WebClient</param>

            public AnimeTitleListKimetsuFromWeb(WebClient wc) : base(wc)
            {
                this.TitleWebList = new List<AnimeTitleSetTextKimetsu>();

                this.TitleLinRegex = new Regex("^<li>.[0-9]{1,3}.*</li>", RegexOptions.Compiled);
            }

            /// <summary>
            /// リストを取得する.
            /// </summary>
            /// <returns>リスト</returns>
            public List<AnimeTitleSetTextKimetsu> GetTitleList()
            {
                var res = this.Url(SorceURL);
                if (res.IsNG)
                {
                    FormMessageBox.Show($@"[鬼滅の刃]のタイトルリストの取得に失敗しました。\n{res.Message}");
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
                    .Right("<h2>鬼滅の刃のサブタイトル一覧</h2>")
                    .Left("<h2>まとめ</h2>");
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
                    var episode = line.Right("<li>").Left("話").Replace("第", "").Trim();
                    var title = line.Right("話").Left("</li>").Trim();

                    // 最後に確保したEpisodeと組み合わせてレコードを生成.
                    var text = new AnimeTitleSetTextKimetsu(
                        episode.ToInt(),
                        title);

                    this.TitleWebList.Add(text);
                }
            }
        }

        /// <summary>
        /// ファイルとの入出力を行う.
        /// </summary>
        public class AnimeTitleListKimetsuFromFile
        {
            /// <summary>
            /// リソースファイル.
            /// </summary>
            private static readonly string FileName = @"KimetsuTitle.list";

            /// <summary>
            /// タイトルリスト.
            /// </summary>
            public List<AnimeTitleSetTextKimetsu> TitleFileList { get; set; }

            /// <summary>
            /// コンストラクタ.
            /// </summary>
            public AnimeTitleListKimetsuFromFile()
            {
                this.TitleFileList = new List<AnimeTitleSetTextKimetsu>();
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
            public static List<AnimeTitleSetTextKimetsu> Load()
            {
                var list = new AnimeTitleListKimetsuFromFile();

                var filePath = GetFilePath();

                // ファイルの存在をチェックし、存在する場合のみ読み込む。
                if (File.Exists(filePath))
                {
                    try
                    {
                        list = JsonIO.Load<AnimeTitleListKimetsuFromFile>(filePath);
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
