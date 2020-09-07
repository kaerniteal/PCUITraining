using Common.Values;
using Common.Web;
using System;
using System.IO;
using System.Net;

namespace PCUITCommon.Datas
{
    /// <summary>
    /// ローカルファイルの存在をチェックして、存在しない場合はWebからファイルをロードする.
    /// </summary>
    /// <remarks></remarks>
    public class FileLoader
    {
        /// <summary>
        /// WebClient
        /// </summary>
        private WebClient Wc { get; set; }

        /// <summary>
        /// パスを含まないファイル名.
        /// </summary>
        public string FileName { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="WebClient">
        /// WebClient：nullを指定しても内部で生成する。
        /// 連続で使用する場合はここで与えておく方がパフォーマンスが良い
        /// </param>
        public FileLoader(WebClient wc = null)
        {
            this.Wc = wc;
        }

        /// <summary>
        /// ファイルの存在をチェックして、無ければWebからロードする.
        /// </summary>
        /// <param name="filePath">
        /// カレントフォルダからの相対パスを指定する。
        /// そのままURLの下のパスとしても利用する為、先頭に.\を付けない。
        /// </param>
        /// <returns>成否</returns>
        public Result Load(string filePath)
        {
            try
            {
                var localPath = $@".\{filePath}";

                // ローカルに存在するなら処理不要.
                if (File.Exists(localPath))
                {
                    return Result.OK();
                }

                // WebClientを用意する.
                if (null == this.Wc)
                {
                    this.Wc = PCUIT.CreateWebClient();
                }

                // ダウンローダーを準備.
                var url = $@"{Def.APP_URL}{filePath.Replace(Path.DirectorySeparatorChar, '/')}";
                var dl = new Downloader(this.Wc);

                // ディレクトリが存在しない場合は生成.
                var folderPath = Path.GetDirectoryName(localPath);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // ロードする.
                return dl.FileDownLoad(url, filePath);
            }
            catch (Exception ex)
            {
                return Result.NG(ex);
            }
        }
    }
}
