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
    public static class JsonIO
    {
        /// <summary>
        /// Json文字列にシリアライズします。
        /// </summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="target">シリアライズするターゲット</param>
        /// <param name="Indented">出力するファイルのインデントを整えるかどうか(default:true)</param>
        /// <returns>シリアライズしたJson文字列</returns>
        public static string Serialize<T>(T target, bool indented = true)
        {
            // シリアライズオプションを設定する.
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),  // これを指定しないと日本語として読めなくなる\uXXXXみたいな値で出力される
                WriteIndented = indented,
            };

            return JsonSerializer.Serialize(target, options);
        }

        /// <summary>
        /// Json文字列をデシリアライズします。
        /// </summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="json">Json文字列</param>
        /// <returns>デシリアライズしたオブジェクト</returns>
        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// Jsonファイルをデシリアライズします。
        /// </summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="path">読み込むファイル</param>
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
        /// Jsonシリアライズしてファイルへ出力する.
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
            if (null != dir && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            // シリアライズしてファイルに出力する.
            var jsonString = Serialize(target, indented);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
