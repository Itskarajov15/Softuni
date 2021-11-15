using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggerProgram.LogFiles
{
    public class LogFile : ILogFile
    {
        private StringBuilder stringBuilder;

        public LogFile()
        {
            stringBuilder = new StringBuilder();
        }

        public int Size => stringBuilder.ToString()
            .Where(c => char.IsLetter(c))
            .Sum(c => c);

        public void Write(string message)
            => stringBuilder.Append(message);
    }
}
