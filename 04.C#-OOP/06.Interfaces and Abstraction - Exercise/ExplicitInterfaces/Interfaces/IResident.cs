﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Interfaces
{
    public interface IResident
    {
        public string Name { get; set; }

        public string Country { get; set; }

        string GetName(string name);
    }
}
