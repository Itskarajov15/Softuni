using LoggerProgram.Layouts;
using LoggerProgram.ReportLevel;
using System;

namespace LoggerProgram.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string dateTime, LogLevel reportLevel, string msg)
        {
            string msgToAppend = string.Format(this.Layout.Format, dateTime, reportLevel, msg);

            this.Count++;

            Console.WriteLine(msgToAppend);
        }
    }
}
