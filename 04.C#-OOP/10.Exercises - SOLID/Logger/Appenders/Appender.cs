using LoggerProgram.Layouts;
using LoggerProgram.ReportLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }
        public LogLevel ReportLevel { get; set; }

        public int Count { get; protected set; }

        public abstract void Append(string dateTime, LogLevel reportLevel, string msg);

        public virtual string GetAppenderInfo()
            => $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.Count}";
    }
}
