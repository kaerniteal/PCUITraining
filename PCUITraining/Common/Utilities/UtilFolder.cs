using Common.Values;
using System;
using System.IO;
using System.Windows.Forms;

namespace Common.Utilities
{
    /// <summary>
    /// フォルダ操作ユーティリティ.
    /// </summary>
    public static class UtilFolder
    {
        /// <summary>
        /// アプリケーションの実行フォルダを取得する.
        /// </summary>
        /// <returns></returns>
        public static string GetAppFolderPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        /// <summary>
        /// アプリケーションの実行フォルダ配下に、指定した名前のフォルダが存在しなければ作成する.
        /// </summary>
        /// <returns>作成したフォルダのフルパス</returns>
        public static string CreateAppLocalFolder(string folderName)
        {
            // フォルダを作成.
            var appPath = GetAppFolderPath();
            var folderPath = $@"{appPath}\{folderName}";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }

        /// <summary>
        /// フォルダパスの最後に\が無ければ\を付与する.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string FolderPathSetSep(string path)
        {
            if (path[path.Length - 1] != Path.DirectorySeparatorChar)
            {
                return path + Path.DirectorySeparatorChar;
            }

            return path;
        }

        /// <summary>
        /// フォルダのコピーを行う.
        /// </summary>
        /// <param name="srcPath">コピー元のフォルダパス</param>
        /// <param name="dstPath">コピー先のフォルダパス</param>
        /// <param name="overwrite">上書きして良いかどうか</param>
        /// <returns>成否</returns>
        public static Result CopyFolder(string srcPath, string dstPath, bool overwrite = true)
        {
            try
            {
                // コピー先のフォルダがないときは作る
                if (!Directory.Exists(dstPath))
                {
                    Directory.CreateDirectory(dstPath);

                    // 属性もコピー
                    File.SetAttributes(dstPath, File.GetAttributes(srcPath));
                }

                // コピー先のフォルダ名の末尾に"\"をつける
                dstPath = FolderPathSetSep(dstPath);

                // コピー元のフォルダにあるファイルをコピー
                var files = Directory.GetFiles(srcPath);
                foreach (var file in files)
                {
                    File.Copy(file, dstPath + Path.GetFileName(file), overwrite);
                }

                //コピー元のフォルダにあるフォルダについて、再帰的に呼び出す
                var dirs = Directory.GetDirectories(srcPath);
                foreach (string dir in dirs)
                {
                    CopyFolder(dir, dstPath + Path.GetFileName(dir));
                }
            }
            catch (Exception ex)
            {
                return Result.NG(ex);
            }

            return Result.OK();
        }

        /// <summary>
        /// フォルダをまるごと削除する.
        /// </summary>
        /// <param name="path">削除対象フォルダのパス</param>
        /// <param name="force">読み取り専用があっても消すかどうか</param>
        /// <returns>成否</returns>
        public static Result DeleteFolder(string path, bool force = true)
        {
            try
            {
                // 存在しない場合は処理不要.
                if (!Directory.Exists(path))
                {
                    return Result.OK();
                }

                // DirectoryInfoオブジェクトの作成
                var di = new DirectoryInfo(path);

                // 強制の場合は.
                if (force)
                {
                    // 読み取り専用属性を削除.
                    RemoveReadonlyAttribute(di);
                }

                // フォルダを根こそぎ削除
                di.Delete(true);
            }
            catch (Exception ex)
            {
                return Result.NG($"フォルダの削除に失敗しました。\n{path}", ex);
            }

            return Result.OK();
        }

        /// <summary>
        /// 対象フォルダの読み取り専用属性をすべて消す.
        /// </summary>
        /// <remarks>
        /// 対象フォルダを含む、再帰的に下位フォルダも全て
        /// </remarks>
        /// <param name="rootDi">属性変更対象のフォルダ情報</param>
        public static void RemoveReadonlyAttribute(DirectoryInfo rootDi)
        {
            // 基のフォルダの属性を変更
            if (FileAttributes.ReadOnly == (rootDi.Attributes & FileAttributes.ReadOnly))
            {
                rootDi.Attributes = FileAttributes.Normal;
            }

            // フォルダ内のすべてのファイルの属性を変更
            foreach (var fi in rootDi.GetFiles())
            {
                if (FileAttributes.ReadOnly == (fi.Attributes & FileAttributes.ReadOnly))
                {
                    fi.Attributes = FileAttributes.Normal;
                }
            }

            // サブフォルダの属性を回帰的に変更
            foreach (var subDi in rootDi.GetDirectories())
            {
                RemoveReadonlyAttribute(subDi);
            }
        }
    }
}
