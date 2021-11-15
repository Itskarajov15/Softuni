using LoggerProgram.Appenders;
using LoggerProgram.ReportLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggerProgram.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = new List<IAppender>();

            this.Appenders.AddRange(appenders);
        }

        public List<IAppender> Appenders { get; }

        public void Critical(string dateTime, string msg)
        {
            Log(dateTime, LogLevel.Critical, msg);
        }

        public void Error(string dateTime, string msg)
        {
            Log(dateTime, LogLevel.Error, msg);
        }

        public void Fatal(string dateTime, string msg)
        {
            Log(dateTime, LogLevel.Fatal, msg);
        }

        public void Info(string dateTime, string msg)
        {
            Log(dateTime, LogLevel.Info, msg);
        }

        public void Warning(string dateTime, string msg)
        {
            Log(dateTime, LogLevel.Warning, msg);
        }

        public string GetLoggerInfo()
        {
            var sb = new StringBuilder();

            foreach (var appender in this.Appenders)
            {
                sb.AppendLine(appender.GetAppenderInfo());
            }

            return sb.ToString().TrimEnd();
        }

        private void Log(string dateTime, LogLevel logLevel, string msg)
        {
            foreach (var appender in this.Appenders)
            {
                if (logLevel >= appender.ReportLevel)
                {
                    appender.Append(dateTime, logLevel, msg);
                }
            }
        }
    }
}
