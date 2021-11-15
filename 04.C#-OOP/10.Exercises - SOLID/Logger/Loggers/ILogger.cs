using LoggerProgram.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Loggers
{
    public interface ILogger
    {
        public List<IAppender> Appenders { get; }

        void Info(string dateTime, string msg);

        void Warning(string dateTime, string msg);

        void Error(string dateTime, string msg);

        void Critical(string dateTime, string msg);

        void Fatal(string dateTime, string msg);

        string GetLoggerInfo();
    }
}
