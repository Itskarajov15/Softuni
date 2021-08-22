﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split()
                .Where(w => w.Length % 2 == 0)
                .ToList()
                .ForEach(word => Console.WriteLine(word));
        }
    }
}
