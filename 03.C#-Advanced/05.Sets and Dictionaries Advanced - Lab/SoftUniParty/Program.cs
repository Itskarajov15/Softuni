using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularGuests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();

            string guest = Console.ReadLine();

            while (guest != "PARTY")
            {
                if (Char.IsDigit(guest[0]))
                {
                    vipGuests.Add(guest);
                }
                else
                {
                    regularGuests.Add(guest);
                }

                guest = Console.ReadLine();
            }

            string arrivedGuest = Console.ReadLine();

            while (arrivedGuest != "END")
            {
                if (vipGuests.Contains(arrivedGuest))
                {
                    vipGuests.Remove(arrivedGuest);
                }

                if (regularGuests.Contains(arrivedGuest))
                {
                    regularGuests.Remove(arrivedGuest);
                }

                arrivedGuest = Console.ReadLine();
            }

            int count = vipGuests.Count + regularGuests.Count;

            Console.WriteLine(count);

            if (vipGuests.Any())
            {
                foreach (var vipGuest in vipGuests)
                {
                    Console.WriteLine(vipGuest);
                }
            }

            if (regularGuests.Any())
            {
                foreach (var regularGuest in regularGuests)
                {
                    Console.WriteLine(regularGuest);
                }
            }
        }
    }
}
