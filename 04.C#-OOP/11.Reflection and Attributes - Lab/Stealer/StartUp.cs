using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            var spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");

            Console.WriteLine(result);
        }
    }
}
