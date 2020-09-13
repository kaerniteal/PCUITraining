using Common.DataIO;
using Common.Values;

namespace Common.Conf
{
    /// <summary>
    /// 設定ファイル基底クラス
    /// </summary>
    /// <typeparam name="T">継承したクラス自身を指定する</typeparam>
    public abstract class JsonConfBase<T> : JsonDataBase<T>, IConfBase where T : class, IConfBase, new()
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public JsonConfBase()
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
            var path = config.GetConfFilePath();

            // 基底クラスのロード処理.
            var loadResult = Load(path);
            if (loadResult.IsOK)
            {
                config = loadResult.Value;
            }

            // 下記の２ケースを想定して毎回出力する
            // ・読み込んだ設定ファイルに項目が不足している場合.
            // ・設定ファイルが存在しない場合.
            config.Save();

            return config;
        }

        /// <summary>
        /// デフォルト保存処理：あらかじめ決められたパスに保存する.
        /// </summary>
        /// <remarks>指定したパスのフォルダが存在しない場合は生成する</remarks>
        /// <returns>成否</returns>
        public Result Save()
        {
            var path = this.GetConfFilePath();

            // 基底クラスの保存処理.
            return base.Save(path);
        }
    }
}
