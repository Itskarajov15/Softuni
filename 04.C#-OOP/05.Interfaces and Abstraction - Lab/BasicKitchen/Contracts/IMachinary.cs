using System;
using System.Collections.Generic;
using System.Text;

namespace BasicKitchen.Contracts
{
    interface IMachinary
    {
        public List<string> Machines { get; set; }

        void ListMachines();
    }
}
