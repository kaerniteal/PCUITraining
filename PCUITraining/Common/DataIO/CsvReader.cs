using Common.Value;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Common.DataIO
{
    /// <summary>
    /// CSVファイルの読み出しを行う.
    /// </summary>
    /// <remarks>参照の追加で、Microsoft.VisualBasic を追加する必要がある</remarks>
    public class CsvReader
    {
        /// <summary>
        /// タイトル行.
        /// </summary>
        public string[] Titles { get; protected set; }

        /// <summary>
        /// レコード行.
        /// </summary>
        public List<string[]> RecoredList { get; protected set; }

        /// <summary>
        /// 見出し行の有無.
        /// </summary>
        public bool HasTitle { get; set; }

        /// <summary>
        /// CSVファイルのエンコーディング.
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// フィールドを読み取る際にTrimするかどうか.
        /// </summary>
        public bool DoTrim { get; set; }

        /// <summary>
        /// フィールドの区切り文字(Defaultは",").
        /// </summary>
        public string Delimiter { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public CsvReader()
        {
            this.Titles = new string[0];
            this.RecoredList = new List<string[]>();
            this.HasTitle = true;
            this.Encoding = Encoding.Default;
            this.DoTrim = true;
            this.Delimiter = @",";
        }

        /// <summary>
        /// 読み取り.
        /// </summary>
        /// <returns>結果</returns>
        public Result ReadCSV(string path)
        {
            try
            {
                // Parserを生成.
                var parser = new TextFieldParser(path, this.Encoding)
                {
                    TextFieldType = FieldType.Delimited,
                    HasFieldsEnclosedInQuotes = true,
                    TrimWhiteSpace = this.DoTrim,
                };

                // カンマ区切りの指定
                parser.SetDelimiters(this.Delimiter);

                // パース.
                using (parser)
                {
                    // ファイルの終端までループ
                    for (var ii = 0; !parser.EndOfData; ii++)
                    {
                        // フィールドを読込
                        var row = parser.ReadFields();

                        // 先頭行のみタイトルとして取得.
                        if (0 == ii && this.HasTitle)
                        {
                            this.Titles = row;
                        }
                        else
                        {
                            this.RecoredList.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Result.NG(ex);
            }

            return Result.OK();
        }
    }
}
