using Common.DataIO;
using Common.Extentions;
using Common.Values;
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
        /// クローン.
        /// </summary>
        public UserData Clone()
        {
            return new UserData
            {
                Name = this.Name,
                FontColorStr = this.FontColorStr,
                UseCustomIcon = this.UseCustomIcon,
                IconFileName = this.IconFileName,
            };
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

            try
            {
                // ファイルの存在をチェックし、存在する場合のみ読み込む。
                if (File.Exists(path))
                {
                    userData = JsonIO.Load<UserData>(path);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox(@"ファイル[{0}]の読み込みに失敗しました}".Fmt(path));
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
        public Result Save()
        {
            CreateUserDataFolder();

            var path = this.CreateUserDataFilePath();

            try
            {
                JsonIO.Save(this, path);
            }
            catch (Exception ex)
            {
                return Result.NG($"ファイルの保存に失敗しました\n{path}", ex);
            }

            return Result.OK(); ;
        }

        /// <summary>
        /// ユーザーデータを削除する.
        /// </summary>
        /// <returns></returns>
        public Result Delete()
        {
            try
            {
                var path = this.CreateUserDataFolderPath();

                //フォルダを根こそぎ削除
                var di = new DirectoryInfo(path);
                di.Delete(true);
            }
            catch (Exception ex)
            {
                return Result.NG("ユーザーデータの削除に失敗しました", ex);
            }

            return Result.OK();
        }

        /// <summary>
        /// アイコンをロードする.
        /// </summary>
        /// <returns>アイコン</returns>
        public Image LoadIcon()
        {
            try
            {
                var path = this.CreateImageFilePath();
                if (File.Exists(path))
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        var img = Image.FromStream(fs);
                        fs.Close();
                        return img;
                    }
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
        public string CreateImageFilePath()
        {
            return this.IconFileName.IsEmpty()
                ? string.Empty
                : Path.Combine(this.CreateUserDataFolderPath(), this.IconFileName);
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
        /// ユーザーデータフォルダを生成する.
        /// </summary>
        private void CreateUserDataFolder()
        {
            try
            {
                var folderPath = CreateUserDataFolderPath();
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("ユーザーフォルダの生成に失敗しました");
            }
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
