using System;
using System.IO;
using System.Threading.Tasks;

namespace LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader str = new StreamReader("input.txt"))
            {
                string line = await str.ReadLineAsync();
                int counter = 1;

                using (StreamWriter wtr = new StreamWriter("Output.txt"))
                {
                    while (line != null)
                    {
                        await wtr.WriteLineAsync($"{counter}. {line}");

                        counter++;
                        line = await str.ReadLineAsync();
                    }
                }
            }
        }
    }
}
