using LoggerProgram.Layouts;
using LoggerProgram.LogFiles;
using LoggerProgram.ReportLevel;
using System;
using System.IO;

namespace LoggerProgram.Appenders
{
    public class FileAppender : Appender
    {
        private const string FilePath = "../../../Output/result.txt";

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public override void Append(string dateTime, LogLevel reportLevel, string msg)
        {
            string messageToAppend = string.Format(this.Layout.Format, dateTime, reportLevel, msg);

            LogFile.Write(msg);

            this.Count++;

            File.AppendAllText(FilePath, messageToAppend + Environment.NewLine);
        }

        public override string GetAppenderInfo()
            => base.GetAppenderInfo() + $", File size: {this.LogFile.Size}";
    }
}
