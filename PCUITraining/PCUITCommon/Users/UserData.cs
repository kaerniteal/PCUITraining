using Common.Extentions;
using System;
using System.Drawing;
using System.IO;

namespace PCUITCommon.Users
{
    /// <summary>
    /// ユーザーデータ.
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// 名前.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// フォントカラー.
        /// </summary>
        public string FontColorStr { get; set; }

        /// <summary>
        /// カスタムアイコンの有無.
        /// </summary>
        public bool UseCustomIcon { get; set; }

        /// <summary>
        /// カスタムアイコンファイル名.
        /// </summary>
        public string IconFileName { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public UserData()
        {
            this.Name = string.Empty;
            this.FontColorStr = Color.White.ToString();
            this.UseCustomIcon = false;
            this.IconFileName = string.Empty;
        }

        /// <summary>
        /// Fontカラーを取得.
        /// </summary>
        /// <returns></returns>
        public Color GetFontColor()
        {
            try
            {
                return ColorTranslator.FromHtml(this.FontColorStr);
            }
            catch
            {
                return Color.White;
            }
        }

        /// <summary>
        /// ユーザーデータ読み込み
        /// </summary>
        public static UserData Load(string name)
        {
            var userData = new UserData
            {
                Name = name,
            };

            var path = userData.CreateUserDataFilePath();

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(path))
            {
                try
                {
                    userData = path.JsonLoad<UserData>();
                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox(@"ファイル[{0}]の読み込みに失敗しました}".Fmt(path));
                }
            }

            // 下記の２ケースを想定して毎回出力する
            // ・読み込んだ設定ファイルに項目が不足している場合.
            // ・設定ファイルが存在しない場合.
            userData.Save();

            return userData;
        }

        /// <summary>
        /// ユーザーデータ保存
        /// </summary>
        public bool Save()
        {
            var path = this.CreateUserDataFilePath();

            try
            {
                this.JsonSave(path);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox(@"ファイル[{0}]の保存に失敗しました}".Fmt(path));
                return false;
            }

            return true;
        }

        /// <summary>
        /// アイコンをロードする.
        /// </summary>
        /// <returns>アイコン</returns>
        public Bitmap LoadIcon()
        {
            try
            {
                if (this.UseCustomIcon)
                {
                    var path = Path.Combine(this.CreateUserDataFolderPath(), this.IconFileName);
                    return new Bitmap(path);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox(@"{0}のアイコンのロードに失敗しました".Fmt(this.Name));
            }

            return null;
        }

        /// <summary>
        /// ユーザーデータフォルダパスを生成する.
        /// </summary>
        /// <returns>ユーザーデータフォルダのPath</returns>
        public string CreateUserDataFolderPath()
        {
            return Path.Combine(UserDataManager.RootPath, this.Name);
        }

        /// <summary>
        /// ユーザーデータファイルパスを生成する.
        /// </summary>
        /// <returns>ユーザーデータファイルパス</returns>
        private string CreateUserDataFilePath()
        {
            return CreateUserDataFolderPath() + @"\{0}.dat".Fmt(this.Name);
        }
    }
}
