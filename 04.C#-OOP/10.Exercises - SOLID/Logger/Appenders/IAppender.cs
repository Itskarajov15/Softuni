using LoggerProgram.Layouts;
using LoggerProgram.ReportLevel;

namespace LoggerProgram.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public LogLevel ReportLevel { get; set; }

        public int Count { get; }

        void Append(string dateTime, LogLevel reportLevel, string msg);

        string GetAppenderInfo();
    }
}
