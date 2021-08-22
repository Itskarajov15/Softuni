using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] parts = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string company = parts[0];
                string emplyeeId = parts[1];

                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }

                companies[company].Add(emplyeeId);
            }

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                List<string> employees = company.Value
                    .Distinct()
                    .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
