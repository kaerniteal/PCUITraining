using Common.Extentions;
using PCUITCommon.Users;
using System;
using System.Collections.Generic;
using System.IO;

namespace MouseExercise.MusExcSet.InsectCollectingSet
{
    /// <summary>
    /// 昆虫採集セットゲームデータ.
    /// </summary>
    public class InsectCollectingSetGameData
    {
        /// <summary>
        /// このデータのファイル名.
        /// </summary>
        public static readonly string FileNameFormat = @"{0}.dat";

        /// <summary>
        /// トータルスコアリスト.
        /// </summary>
        public List<int> ScoreList { get; set; }

        /// <summary>
        /// データレコードリスト.
        /// </summary>
        public List<InsectCollectingSetGameDataRecord> RecordList { get; set; }


        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public InsectCollectingSetGameData()
        {
            this.RecordList = new List<InsectCollectingSetGameDataRecord>();
            this.ScoreList = new List<int>();
        }

        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <remarks>ロードが成功した場合新たなインスタンスを返す。失敗した場合は自身を返す</remarks>
        /// <param name="userData">対象ユーザーデータ</param>
        /// <returns></returns>
        public static InsectCollectingSetGameData Load(UserData userData)
        {
            var gameData = new InsectCollectingSetGameData();

            var userPath = userData.CreateUserDataFolderPath();
            var folderPath = gameData.CreateDataFolder(userPath);
            var filePath = folderPath + FileNameFormat.Fmt(InsectCollectingSet.Name);

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(filePath))
            {
                try
                {
                    gameData = filePath.JsonLoad<InsectCollectingSetGameData>();
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
        public bool Save(UserData userData)
        {
            var userPath = userData.CreateUserDataFolderPath();
            var folderPath = CreateDataFolder(userPath);
            var filePath = folderPath + FileNameFormat.Fmt(InsectCollectingSet.Name);

            try
            {
                this.JsonSave(filePath);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox(@"ファイル[{0}]の保存に失敗しました}".Fmt(filePath));
                return false;
            }

            return true;
        }

        /// <summary>
        /// このデータを格納するフォルダのパス.
        /// </summary>
        /// <param name="userPath">保存先ユーザーPath</param>
        /// <returns>フォルダパス</returns>
        private string CreateDataFolder(string userPath)
        {
            var folderPath = @"{0}\{1}\".Fmt(userPath, InsectCollectingSet.Name);

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
