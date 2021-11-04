using System;
using System.Collections.Generic;
using System.Globalization;

namespace BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var citizens = new List<IBornable>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Citizen")
                {
                    citizens.Add(new Person(parts[1], int.Parse(parts[2]), parts[3],
                        DateTime.ParseExact(parts[4], "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                }
                else if (parts[0] == "Pet")
                {
                    citizens.Add(new Pet(parts[1], DateTime.ParseExact(parts[2], "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                }
            }

            try
            {
                string date = Console.ReadLine();

                foreach (var citizen in citizens)
                {
                    string dateToCompare = citizen.Birthdate.Year.ToString();
                    if (dateToCompare == date)
                    {
                        Console.WriteLine(citizen.Birthdate.ToString("dd/MM/yyyy"));
                    }
                }
            }
            catch (Exception ex)
            {
                ex = new ArgumentException("<empty output>");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
