using LoggerProgram.Appenders;
using LoggerProgram.Layouts;
using LoggerProgram.LogFiles;
using LoggerProgram.Loggers;
using LoggerProgram.ReportLevel;
using System;

namespace LoggerProgram
{
    class Program
    {
        public static Logger ILogger { get; private set; }

        static void Main(string[] args)
        {
            ILogger logger = new Logger();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var appenderInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = appenderInfo[0];
                string layoutType = appenderInfo[1];

                IAppender appender = null;
                ILayout layout = null;

                if (layoutType == "SimpleLayout")
                {
                    layout = new SimpleLayout();
                }
                else if (layoutType == "XmlLayout")
                {
                    layout = new XmlLayout();
                }

                if (type == "ConsoleAppender")
                {
                    appender = new ConsoleAppender(layout);
                }
                else if (type == "FileAppender")
                {
                    ILogFile logFile = new LogFile();

                    appender = new FileAppender(layout, logFile);
                }

                if (appenderInfo.Length == 3)
                {
                    bool isValidLogLevel = Enum.TryParse(appenderInfo[2], true, out LogLevel logLevel);

                    if (isValidLogLevel)
                    {
                        appender.ReportLevel = logLevel;
                    }
                }

                logger.Appenders.Add(appender);
            }
             
            string input = Console.ReadLine();

            while (input != "END")
            {
                var messageInfo = input.Split("|", StringSplitOptions.RemoveEmptyEntries);

                string logLevel = messageInfo[0];
                string date = messageInfo[1];
                string message = messageInfo[2];

                bool isValidLogLevel = Enum.TryParse(logLevel, true, out LogLevel messageLogLevel);

                if (!isValidLogLevel)
                {
                    input = Console.ReadLine();
                    continue;
                }

                //TODO: Factory

                if (messageLogLevel == LogLevel.Info)
                {
                    logger.Info(date, message);
                }

                if (messageLogLevel == LogLevel.Warning)
                {
                    logger.Warning(date, message);
                }

                if (messageLogLevel == LogLevel.Error)
                {
                    logger.Error(date, message);
                }

                if (messageLogLevel == LogLevel.Fatal)
                {
                    logger.Fatal(date, message);
                }

                if (messageLogLevel == LogLevel.Critical)
                {
                    logger.Critical(date, message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Logger info");
            Console.WriteLine(logger.GetLoggerInfo());
        }
    }
}
