using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository.Hierarchy;
using System;
using System.IO;

namespace Common.Logger
{
    /// <summary>
    /// Log4netを利用したログ出力クラス.
    /// </summary>
    /// <remarks>
    /// 使い方
    ///  1.CommonプロジェクトにNugetでLog4netをインストールする.
    ///  
    ///  2.CommonプロジェクトのPropertiesのAssemblyInfo.csに下記の記述を追加する.
    ///    [assembly: log4net.Config.XmlConfigurator(Watch = true, ConfigFile = "log4net.config")]
    ///    
    ///  3.実行モジュールを生成するプロジェクトのRootに
    ///  　[log4net.config]を設置(log4net.config.templateを複製してリネーム)し、
    ///  　そのファイルのプロパティで出力ディレクトリに[新しければコピー]をセットする.
    ///    
    ///  4.log4net.config の内容はそれぞれのプロジェクトで見直すこと.
    ///  　特に<File value=".\logs\App.log" />はアプリの名前に変更すべき.
    ///    
    ///  5.ログを出力したいクラスのstaticメンバにこのクラスのインスタンスをセットし、ログを出力する.
    ///  　private static Log4netLogger Log = new Log4netLogger(MethodBase.GetCurrentMethod().DeclaringType);
    ///  
    /// </remarks>

    public class Log4netLogger
    {
        /// <summary>
        /// ログレベル.
        /// </summary>
        public enum LogLv
        {
            ALL = 0,
            DEBUG = 1,
            INFO = 2,
            WARN = 3,
            ERROR = 4,
            FATAL = 5,
            NOLOG = 9,
        }

        /// <summary>
        /// ログレベル.
        /// </summary>
        public static LogLv Lv { get; private set; }

        /// <summary>
        /// log4netインスタンス.
        /// </summary>
        private ILog Log4net { get; set; }


        /// <summary>
        /// 静的コンストラクタ.
        /// </summary>
        static Log4netLogger()
        {
            Lv = LogLv.DEBUG;
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <remarks>
        /// 引数には固定で[MethodBase.GetCurrentMethod().DeclaringType]を渡す
        /// </remarks>
        /// <param name="type">ログを使用するクラスのType</param>
        public Log4netLogger(Type type)
        {
            this.Log4net = LogManager.GetLogger(type);
        }

        /// <summary>
        /// 出力するログレベルを変更する.
        /// </summary>
        /// <remarks>
        /// log4net.configのRootに対して設定するため
        /// 複雑なパターンには対応できないかもしれない.
        /// </remarks>
        /// <param name="lv">ログレベル</param>
        public static void SetLogLv(LogLv lv)
        {
            // ログレベルを設定.
            Lv = lv;

            // ダミーLoggerからRootのLoggerを取得
            var dummylogger = LogManager.GetLogger("dummylogger");
            var rootLogger = ((Hierarchy)dummylogger.Logger.Repository).Root;

            // Log4netの出力を変更.
            switch (lv)
            {
                case LogLv.NOLOG: rootLogger.Level = Level.Off; break;
                case LogLv.FATAL: rootLogger.Level = Level.Fatal; break;
                case LogLv.ERROR: rootLogger.Level = Level.Error; break;
                case LogLv.WARN: rootLogger.Level = Level.Warn; break;
                case LogLv.INFO: rootLogger.Level = Level.Info; break;
                case LogLv.DEBUG: rootLogger.Level = Level.Debug; break;
                case LogLv.ALL: rootLogger.Level = Level.All; break;
            }
        }

        /// <summary>
        /// 致命的エラー(アプリケーションが継続不可能なエラー).
        /// </summary>
        /// <param name="log">ログ</param>
        public void Fatal(string log)
        {
            if (Lv <= LogLv.FATAL)
            {
                this.Log4net.Fatal(log);
                Logger.Write($@"[Fatal]{log}");
            }
        }

        /// <summary>
        /// エラー.
        /// </summary>
        /// <param name="log">ログ</param>
        public void Error(string log)
        {
            if (Lv <= LogLv.ERROR)
            {
                this.Log4net.Error(log);
                Logger.Write($@"[Error]{log}");
            }
        }

        /// <summary>
        /// 警告.
        /// </summary>
        /// <param name="log">ログ</param>
        public void Warn(string log)
        {
            if (Lv <= LogLv.WARN)
            {
                this.Log4net.Warn(log);
                Logger.Write($@"[Warn]{log}");
            }
        }

        /// <summary>
        /// 情報.
        /// </summary>
        /// <param name="log">ログ</param>
        public void Info(string log)
        {
            if (Lv <= LogLv.INFO)
            {
                this.Log4net.Info(log);
                Logger.Write($@"[Info]{log}");
            }
        }

        /// <summary>
        /// デバッグ.
        /// </summary>
        /// <param name="log">ログ</param>
        public void Debug(string log)
        {
            if (Lv <= LogLv.DEBUG)
            {
                this.Log4net.Debug(log);
                Logger.Write($@"[Debug]{log}");
            }
        }
    }
}
