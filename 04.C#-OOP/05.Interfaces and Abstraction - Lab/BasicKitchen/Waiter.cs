using BasicKitchen.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicKitchen
{
    public class Waiter
    {
        public IOrderable Kitchen { get; set; }
    }
}
