using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Common.Extentions
{
    /// <summary>
    /// Json ドキュメントをシリアラズ－デシリアライズするための拡張メソッドを定義します.
    /// </summary>
    public static class JsonExtensions
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
        public static T JsonLoad<T>(this string self) where T : class
        {
            if (string.IsNullOrEmpty(self))
            {
                throw new ArgumentNullException();
            }

            if (!File.Exists(self))
            {
                throw new FileNotFoundException("指定したファイルが見つかりません", self);
            }

            // ファイルを読み取りデシリアライズする.
            var jsonString = File.ReadAllText(self);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// Jsonシリアライズして出力する.
        /// </summary>
        /// <param name="self">自分自身</param>
        /// <param name="filePath">出力先パス</param>
        /// <param name="Indented">出力するファイルのインデントを整えるかどうか(default:true)</param>
        public static void JsonSave(this object self, string filePath, bool indented = true)
        {
            if ((null == self) || string.IsNullOrEmpty(filePath))
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
            var jsonString = JsonSerializer.Serialize(self, options);
            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// シリアライズオプションを取得する.
        /// </summary>
        /// <returns>シリアライズオプション</returns>
        private static JsonSerializerOptions GetSerializerOption()
        {
            // シリアライズオプションを設定する.
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),  // これを指定しないと日本語として読めなくなる\uXXXXみたいな値で出力される
                WriteIndented = true,
            };

            // ENUMを文字列で出力する.
            options.Converters.Add(new JsonStringEnumConverter());

            return options;
        }
    }
}
