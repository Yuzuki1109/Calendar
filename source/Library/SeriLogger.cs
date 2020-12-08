using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;
using System;
using System.IO;
using Windows.Storage;

namespace Library
{
    /// <summary>
    /// ロガークラス
    /// </summary>
    public static class SeriLogger
    {
        #region const
        /// <summary>
        /// ログテンプレート
        /// </summary>
        private const string LogTemplate = "{AssemblyName}(v{AssemblyVersion}) [{Level:u4}] {Timestamp:yyyy/MM/dd-HH:mm:ss}[{ThreadId:00}] - {Message:j}{NewLine}";

        /// <summary>
        /// エラーログテンプレート
        /// </summary>
        private const string ErrorLogTemplate = LogTemplate + "{Exception}{NewLine}";

        #endregion

        #region properties

        /// <summary>
        /// 初期化済フラグ
        /// </summary>
        private static bool Initialized = false;

        #endregion

        #region public

        /// <summary>
        /// インフォログ出力
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="values">埋め込みオブジェクト</param>
        public static void Info(String str, params object[] values)
        {
            OutputLog(LogEventLevel.Information, str, values);
        }

        /// <summary>
        /// ワーニングログ出力
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="values">埋め込みオブジェクト</param>
        public static void Warn(String str, params object[] values)
        {
            OutputLog(LogEventLevel.Warning, str, values);
        }

        /// <summary>
        /// エラーログ出力
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="values">埋め込みオブジェクト</param>
        public static void Error(String str, params object[] values)
        {
            OutputLog(LogEventLevel.Error, str, values);
        }

        /// <summary>
        /// エラーログ出力
        /// </summary>
        /// <param name="e">例外</param>
        public static void Error(Exception e)
        {
            OutoutErrorLog(LogEventLevel.Error, e);
        }

        /// <summary>
        /// 致命的なエラーログ出力
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="values">埋め込みオブジェクト</param>
        public static void Fatal(String str, params object[] values)
        {
            OutputLog(LogEventLevel.Fatal, str, values);
        }

        /// <summary>
        /// 致命的なエラーログ出力
        /// </summary>
        /// <param name="e">例外</param>
        public static void Fatal(Exception e)
        {
            OutoutErrorLog(LogEventLevel.Fatal, e);
        }

        #endregion

        #region private

        /// <summary>
        /// ログ出力本体
        /// </summary>
        /// <param name="level">出力レベル</param>
        /// <param name="str">文字列</param>
        /// <param name="values">埋め込みオブジェクト</param>
        private static void OutputLog(LogEventLevel level, String str, params object[] values)
        {
            if (!Initialized) Init();

            switch (level)
            {
                case LogEventLevel.Debug:

                    Log.Debug(str, values);

                    break;

                case LogEventLevel.Information:

                    Log.Information(str, values);

                    break;

                case LogEventLevel.Warning:

                    Log.Warning(str, values);

                    break;

                case LogEventLevel.Error:

                    Log.Error(str, values);

                    break;

                case LogEventLevel.Fatal:

                    Log.Fatal(str, values);

                    break;
            }
        }

        /// <summary>
        /// 例外からエラーログ出力
        /// </summary>
        /// <param name="level">出力レベル</param>
        /// <param name="e">例外</param>
        private static void OutoutErrorLog(LogEventLevel level, Exception e)
        {
            if (!Initialized) Init();

            switch (level)
            {
                case LogEventLevel.Error:

                    Log.Error(e, e.Message);

                    break;

                case LogEventLevel.Fatal:

                    Log.Fatal(e, e.Message);

                    break;
            }
        }

        /// <summary>
        /// ロガー初期化
        /// </summary>
        private static void Init()
        {
            string PathFormat = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Log", "{0}_.log");

            Log.Logger = new LoggerConfiguration()
                    .Enrich.WithThreadId()
                    .Enrich.WithAssemblyName()
                    .Enrich.WithAssemblyVersion()
                    .Enrich.WithExceptionDetails()
                    .MinimumLevel.Debug()
                    .WriteTo.Console(outputTemplate: LogTemplate)
                    .WriteTo.Debug(outputTemplate: LogTemplate)
                    .WriteTo.File(String.Format(PathFormat, "Debug"), LogEventLevel.Debug, outputTemplate: LogTemplate, rollingInterval: RollingInterval.Day)
                    .WriteTo.File(String.Format(PathFormat, "Info"), LogEventLevel.Information, outputTemplate: LogTemplate, rollingInterval: RollingInterval.Day)
                    .WriteTo.File(String.Format(PathFormat, "Warn"), LogEventLevel.Warning, outputTemplate: LogTemplate, rollingInterval: RollingInterval.Day)
                    .WriteTo.File(String.Format(PathFormat, "Error"), LogEventLevel.Error, outputTemplate: ErrorLogTemplate, rollingInterval: RollingInterval.Day)
                    .WriteTo.File(String.Format(PathFormat, "Fatal"), LogEventLevel.Fatal, outputTemplate: ErrorLogTemplate, rollingInterval: RollingInterval.Day)
                    .CreateLogger();

            Initialized = true;
        }

        #endregion

    }
}
