using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@(#{1,})([A-Z][A-Za-z0-9]{4,}[A-Z])@(#{1,})";

            int countOfBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfBarcodes; i++)
            {
                StringBuilder group = new StringBuilder();

                string currBarcode = Console.ReadLine();

                MatchCollection barcodeMatch = Regex.Matches(currBarcode, pattern);

                if (!Regex.IsMatch(currBarcode, pattern))
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                foreach (Match barcode in barcodeMatch)
                {
                    foreach (char symbol in barcode.Value)
                    {
                        if (Char.IsDigit(symbol))
                        {
                            group.Append(symbol);
                        }
                    }
                }

                if (group.Length <= 0)
                {
                    Console.WriteLine($"Product group: 00");
                }
                else
                {
                    Console.WriteLine($"Product group: {group}");
                }
            }
        }
    }
}
