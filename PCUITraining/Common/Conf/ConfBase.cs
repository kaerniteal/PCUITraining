using Common.DataIO;
using Common.Extentions;
using Common.Value;
using System;
using System.IO;

namespace Common.Conf
{
    /// <summary>
    /// 設定ファイル基底クラス
    /// </summary>
    /// <typeparam name="T">継承したクラス自身を指定する</typeparam>
    public abstract class ConfBase<T> : IConfBase where T : class, IConfBase, new()
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ConfBase()
        {
            this.SetDefault();
        }

        /// <summary>
        /// IConfBaseの実装：設定ファイルパスを返す.
        /// </summary>
        /// <returns>設定ファイルのパス</returns>
        public abstract string GetConfFilePath();

        /// <summary>
        /// デフォルトをセット.
        /// </summary>
        public abstract void SetDefault();


        /// <summary>
        /// ロード処理.
        /// </summary>
        /// <remarks>失敗時にはNULLを返す</remarks>
        /// <returns>設定ファイル</returns>
        public static T Load()
        {
            var config = new T();
            var confFile = config.GetConfFilePath();

            // ファイルの存在をチェックし、存在する場合のみ読み込む。
            if (File.Exists(confFile))
            {
                try
                {
                    config = JsonIO<T>.Load(confFile);
                }
                catch (Exception ex)
                {
                    ex.ShowMessageBox($@"ファイル[{confFile}]の読み込みに失敗しました");
                }
            }

            // 下記の２ケースを想定して毎回出力する
            // ・読み込んだ設定ファイルに項目が不足している場合.
            // ・設定ファイルが存在しない場合.
            config.Save();

            return config;
        }

        /// <summary>
        /// IConfBaseの実装：保存処理.
        /// </summary>
        /// <remarks>指定したパスのフォルダが存在しない場合は生成する</remarks>
        /// <returns>成否</returns>
        public Result Save()
        {
            var confFile = this.GetConfFilePath();

            try
            {
                // 対象のディレクトリが存在しない場合は生成する.
                var folder = Path.GetDirectoryName(confFile);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var target = this as T;
                JsonIO<T>.Save(target, confFile);
            }
            catch (Exception ex)
            {
                return Result.NG($@"ファイル[{confFile}]の保存に失敗しました", ex);
            }

            return Result.OK();
        }
    }
}
