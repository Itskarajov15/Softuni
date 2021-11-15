using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.LogFiles
{
    public interface ILogFile
    {
        public int Size { get; }

        void Write(string message);
    }
}
