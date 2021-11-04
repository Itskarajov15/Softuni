using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : IBrowsable, ICallable
    {
        public void Browse(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
