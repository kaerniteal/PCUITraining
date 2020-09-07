using Common.Values;
using System;
using System.IO;

namespace Common.DataIO
{
    /// <summary>
    /// Jsonデータ基底クラス
    /// </summary>
    /// <typeparam name="T">継承したクラス自身を指定する</typeparam>
    public abstract class JsonDataBase<T> where T : class, new()
    {
        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <remarks>失敗時にはNULLを返す</remarks>
        /// <param name="filePath">ロードするファイルパス</param>
        /// <param name="instance">生成したインスタンス：失敗時にはnullを返す</param>
        /// <returns>成否</returns>
        public static Result Load(string filePath, out T instance)
        {
            instance = new T();

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(filePath))
            {
                try
                {
                    instance = JsonIO.Load<T>(filePath);
                }
                catch (Exception ex)
                {
                    return Result.NG($@"ファイル[{filePath}]の読み込みに失敗しました", ex);
                }
            }

            return Result.OK();
        }

        /// <summary>
        /// 保存処理.
        /// </summary>
        /// <remarks>指定したパスのフォルダが存在しない場合は生成する</remarks>
        /// <param name="filePath">保存するファイルパス</param>
        /// <returns>成否</returns>
        public Result Save(string filePath)
        {
            try
            {
                var target = this as T;
                JsonIO.Save(target, filePath);
            }
            catch (Exception ex)
            {
                return Result.NG($@"ファイル[{filePath}]の保存に失敗しました", ex);
            }

            return Result.OK();
        }

        /// <summary>
        /// シリアライズ処理.
        /// </summary>
        /// <param name="json">シリアライズしたJson文字列</param>
        /// <returns>成否</returns>
        public Result Serialize(out string json)
        {
            json = string.Empty;

            try
            {
                var target = this as T;
                json = JsonIO.Serialize(target);
            }
            catch (Exception ex)
            {
                return Result.NG($@"シリアライズに失敗しました", ex);
            }

            return Result.OK();
        }

        /// <summary>
        /// デシリアライズ.
        /// </summary>
        /// <remarks>失敗時にはNULLを返す</remarks>
        /// <param name="json">デシリアライズするJson文字列</param>
        /// <param name="instance">生成したインスタンス：失敗時にはnullを返す</param>
        /// <returns>成否</returns>
        public static Result Deserialize(string json, out T instance)
        {
            instance = new T();

            try
            {
                instance = JsonIO.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                return Result.NG($@"デシリアライズに失敗しました", ex);
            }

            return Result.OK();
        }
    }
}
