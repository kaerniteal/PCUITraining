using System;
using System.Collections.Generic;

namespace Common.Logger
{
    /// <summary>
    /// ログクラス.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// ログバッファ最大数.
        /// </summary>
        private const int LOG_MAX = 1024;

        /// <summary>
        /// ログバッファ.
        /// </summary>
        private static List<string> LogBuffer = new List<string>();

        /// <summary>
        /// ログWrite I/F リスト.
        /// </summary>
        private static List<ILogWriter> LogWriterList = new List<ILogWriter>();


        /// <summary>
        /// コンソールへの出力を追加する.
        /// </summary>
        public static void AddConsoleLogWriter()
        {
            LogWriterList.Add(new ConsoleLogWriter());
        }

        /// <summary>
        /// ログWriter I/Fを追加.
        /// </summary>
        /// <param name="writer">追加するWriter</param>
        public static void AddWriter(ILogWriter writer)
        {
            LogWriterList.Add(writer);
        }

        /// <summary>
        /// ログWriter I/Fを削除.
        /// </summary>
        /// <param name="writer">削除するWriter</param>
        public static void RemoveWriter(ILogWriter writer)
        {
            LogWriterList.Remove(writer);
        }

        /// <summary>
        /// ログの書き込み.
        /// </summary>
        /// <param name="log">ログ</param>
        public static void Write(string log)
        {
            var text = $"{DateTime.Now:HH:mm:ss.fff}: {log}";
            if (!text.EndsWith("\r\n"))
            {
                text += "\r\n";
            }

            // 出力先があれば.
            if (0 < LogWriterList.Count)
            {
                foreach (var writer in LogWriterList)
                {
                    // バッファに蓄積があれば.
                    foreach (var line in LogBuffer)
                    {
                        writer.WriteLine(line);
                    }

                    writer.WriteLine(text);
                }

                LogBuffer.Clear();
            }
            else
            {
                // 出力先が無い場合はバッファする.
                LogBuffer.Add(text);
                if (LOG_MAX < LogBuffer.Count)
                {
                    // 蓄積最大を超えた場合は削除.
                    LogBuffer.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// コンソール出力.
        /// </summary>

        public class ConsoleLogWriter : ILogWriter
        {
            /// <summary>
            /// ILogWriterの実装.
            /// </summary>
            /// <param name="log">出力するログメッセージ</param>
            public void WriteLine(string log)
            {
                Console.Write(log);
            }
        }
    }
}
