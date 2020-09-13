using Common.DataIO;
using Common.Values;
using System.IO;
using System.Windows.Forms;

namespace Common.Versions
{
    /// <summary>
    /// バージョンを表すクラス.
    /// </summary>
    public class Ver : JsonDataBase<Ver>
    {
        /// <summary>
        /// バージョンを表すファイルの拡張子.
        /// </summary>
        public static readonly string VER_EXT = "version";

        /// <summary>
        /// メジャーバージョン.
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// マイナーバージョン.
        /// </summary>
        public int Minor { get; set; }

        /// <summary>
        /// ビルドバージョン.
        /// </summary>
        public int Build { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public Ver()
        {
            this.Major = 0;
            this.Minor = 0;
            this.Build = 0;
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="major">Major</param>
        /// <param name="minor">Minor</param>
        /// <param name="build">Build</param>
        /// <param name="saveFile">インスタンス生成時にファイル出力するかどうか</param>
        public Ver(int major, int minor, int build, bool saveFile = true)
        {
            this.Major = major;
            this.Minor = minor;
            this.Build = build;

            if (saveFile)
            {
                this.Save();
            }
        }

        /// <summary>
        /// バージョン比較.
        /// </summary>
        /// <remarks>自身と引数のバージョンを比較する.</remarks>
        /// <param name="dst">比較対象</param>
        /// <returns>
        /// 正の値：引数の方が新しい
        /// ０　　：一致
        /// 負の値：引数の方が古い
        /// </returns>
        public int Compare(Ver dst)
        {
            if (dst.Major != this.Major)
            {
                return dst.Major - this.Major;
            }

            if (dst.Minor != this.Minor)
            {
                return dst.Minor - this.Minor;
            }

            return dst.Build - this.Build;
        }

        /// <summary>
        /// バージョンアップが必要かどうか.
        /// </summary>
        /// <param name="dst">比較対象バージョン</param>
        /// <returns>true：比較対象の方が新しい</returns>
        public bool NeedUpdate(Ver dst)
        {
            return 0 < this.Compare(dst);
        }

        /// <summary>
        /// 文字列化メソッドのオーバーライド.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Major}.{this.Minor}.{this.Build}";
        }

        /// <summary>
        /// アプリケーションフォルダにバージョンファイルを保存する.
        /// </summary>
        public Result Save()
        {
            // アプリケーションパスを取得.
            var appPath = Application.ExecutablePath;
            var appName = Path.GetFileNameWithoutExtension(appPath);
            var folderPath = Path.GetDirectoryName(appPath);

            // 保存する.
            return this.Save($@"{folderPath}\{appName}.{VER_EXT}");
        }
    }
}
