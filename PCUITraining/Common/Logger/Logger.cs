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
            LogBuffer.Add($"{DateTime.Now:HH:mm:ss.fff}: {log}");

            if (LOG_MAX < LogBuffer.Count)
            {
                LogBuffer.RemoveAt(0);
            }

            // 出力先があれば.
            if (0 < LogWriterList.Count)
            {
                foreach (var writer in LogWriterList)
                {
                    foreach (var line in LogBuffer)
                    {
                        if (!line.EndsWith("\r\n"))
                        {
                            writer.WriteLine(line + "\r\n");
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                LogBuffer.Clear();
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
            /// <param name="log"></param>
            public void WriteLine(string log)
            {
                Console.Write(log);
            }
        }
    }
}
