using Common.Extentions;
using System;
using System.Collections.Generic;
using System.IO;

namespace TypingExercise.WordSet.PokemonTyping
{
    /// <summary>
    /// ポケットモンスターゲームデータ.
    /// </summary>
    public class PocketMonsterGameData
    {
        /// <summary>
        /// このデータのファイル名.
        /// </summary>
        public static readonly string FileNameFormat = @"{0}.dat";

        /// <summary>
        /// データレコードリスト.
        /// </summary>
        public List<PocketMonsterGameDataRecord> RecordList { get; set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public PocketMonsterGameData()
        {
            this.RecordList = new List<PocketMonsterGameDataRecord>();
        }

        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <remarks>ロードが成功した場合新たなインスタンスを返す。失敗した場合は自身を返す</remarks>
        /// <param name="userPath">保存先ユーザーPath</param>
        /// <returns></returns>
        public static PocketMonsterGameData Load(string userPath)
        {
            var userData = new PocketMonsterGameData();

            var folderPath = userData.CreateDataFolder(userPath);
            var filePath = folderPath + FileNameFormat.Fmt(PocketMonsterSet.Name);

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(filePath))
            {
                try
                {
                    userData = filePath.JsonLoad<PocketMonsterGameData>();
                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox(@"ファイル[{0}]の読み込みに失敗しました}".Fmt(filePath));
                }
            }

            // 下記の２ケースを想定して毎回出力する
            // ・読み込んだ設定ファイルに項目が不足している場合.
            // ・設定ファイルが存在しない場合.
            userData.Save(userPath);

            return userData;
        }

        /// <summary>
        /// 保存処理.
        /// </summary>
        /// <param name="rootPath">保存先のPath</param>
        public bool Save(string userPath)
        {
            var folderPath = CreateDataFolder(userPath);
            var filePath = folderPath + FileNameFormat.Fmt(PocketMonsterSet.Name);

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
        public string CreateDataFolder(string userPath)
        {
            var folderPath = @"{0}\{1}\".Fmt(userPath, PocketMonsterSet.Name);

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
