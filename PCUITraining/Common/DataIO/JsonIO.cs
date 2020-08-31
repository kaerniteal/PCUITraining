using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Common.DataIO
{
    /// <summary>
    /// Jsonデータとの入出力を行う.
    /// </summary>
    /// <remarks>NuGetでText.Jsonをインポートする必要がある</remarks>
    /// <typeparam name="T">ターゲットクラス</typeparam>
    public static class JsonIO
    {
        /// <summary>
        /// Jsonドキュメントをデシリアライズします。
        /// </summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="self">自分自身</param>
        /// <returns>デシリアライズしたオブジェクト</returns>
        /// <exception cref="ArgumentNullException">ファイル名が空文字の場合に発生します。</exception>
        /// <exception cref="FileNotFoundException">指定したファイルが見つからない場合に発生します。</exception>
        /// <exception cref="InvalidOperationException">シリアライズに失敗した場合に発生します。</exception>
        public static T Load<T>(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("指定したファイルが見つかりません", path);
            }

            // ファイルを読み取りデシリアライズする.
            var jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// Jsonシリアライズして出力する.
        /// </summary>
        /// <typeparam name="T">第一引数の型</typeparam>
        /// <param name="target">シリアライズするターゲット</param>
        /// <param name="filePath">出力先パス</param>
        /// <param name="Indented">出力するファイルのインデントを整えるかどうか(default:true)</param>
        public static void Save<T>(T target, string filePath, bool indented = true)
        {
            if ((null == target) || string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException();
            }

            // ディレクトリがない場合は作っておく。
            var dir = Path.GetDirectoryName(filePath);
            if (null != dir)
            {
                Directory.CreateDirectory(dir);
            }

            // シリアライズオプションを設定する.
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),  // これを指定しないと日本語として読めなくなる\uXXXXみたいな値で出力される
                WriteIndented = indented,
            };

            // ENUMを文字列で出力する.
            //            options.Converters.Add(new JsonStringEnumConverter());

            // シリアライズしてファイルに出力する.
            var jsonString = JsonSerializer.Serialize(target, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
