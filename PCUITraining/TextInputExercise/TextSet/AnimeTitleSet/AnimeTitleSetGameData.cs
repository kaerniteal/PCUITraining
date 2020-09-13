using Common.DataIO;
using Common.Extentions;
using Common.Values;
using PCUITCommon.Users;
using System;
using System.Collections.Generic;
using System.IO;

namespace TextInputExercise.TextSet.AnimeTitleSet
{
    /// <summary>
    /// アニタイライティングゲームデータ.
    /// </summary>
    public class AnimeTitleSetGameData
    {
        /// <summary>
        /// このデータのファイル名.
        /// </summary>
        public static readonly string FileNameFormat = @"{0}.dat";

        /// <summary>
        /// ユーザー毎設定.
        /// </summary>
        public TextConf TextConf { get; set; }

        /// <summary>
        /// データレコードリスト.
        /// </summary>
        public List<AnimeTitleSetGameDataRecord> RecordList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public AnimeTitleSetGameData()
        {
            this.TextConf = new TextConf();
            this.RecordList = new List<AnimeTitleSetGameDataRecord>();
        }


        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <remarks>ロードが成功した場合新たなインスタンスを返す。失敗した場合は自身を返す</remarks>
        /// <param name="userData">対象ユーザーデータ</param>
        /// <returns></returns>
        public static AnimeTitleSetGameData Load(UserData userData)
        {
            var gameData = new AnimeTitleSetGameData();

            var userPath = userData.CreateUserDataFolderPath();
            var folderPath = gameData.CreateDataFolder(userPath);
            var filePath = folderPath + FileNameFormat.Fmt(AnimeTitleSet.Name);

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(filePath))
            {
                try
                {
                    gameData = JsonIO.Load<AnimeTitleSetGameData>(filePath);
                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox(@"ファイル[{0}]の読み込みに失敗しました}".Fmt(filePath));
                }
            }

            // 下記の２ケースを想定して毎回出力する
            // ・読み込んだ設定ファイルに項目が不足している場合.
            // ・設定ファイルが存在しない場合.
            gameData.Save(userData);

            return gameData;
        }

        /// <summary>
        /// 保存処理.
        /// </summary>
        /// <param name="userData">対象ユーザーデータ</param>
        /// <returns>成否</returns>
        public Result Save(UserData userData)
        {
            var userPath = userData.CreateUserDataFolderPath();
            var folderPath = CreateDataFolder(userPath);
            var filePath = folderPath + FileNameFormat.Fmt(AnimeTitleSet.Name);

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

        /// <summary>
        /// このデータを格納するフォルダのパス.
        /// </summary>
        /// <param name="userPath">保存先ユーザーPath</param>
        /// <returns>フォルダパス</returns>
        private string CreateDataFolder(string userPath)
        {
            var folderPath = @"{0}\{1}\".Fmt(userPath, AnimeTitleSet.Name);

            try
            {
                // 存在しない場合は作成する.
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox("{0}ディレクトリの生成に失敗しました。".Fmt(folderPath));
            }

            return folderPath;
        }
    }
}
