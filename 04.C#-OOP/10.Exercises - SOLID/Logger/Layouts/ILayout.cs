using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProgram.Layouts
{
    public interface ILayout
    {
        public string Format { get; }
    }
}
