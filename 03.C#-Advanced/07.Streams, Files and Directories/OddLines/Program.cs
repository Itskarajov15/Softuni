using System;
using System.IO;
using System.Threading.Tasks;

namespace OddLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using(StreamReader str = new StreamReader("input.txt"))
            {
                string line = await str.ReadLineAsync();
                int counter = 0;

                while(line != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;
                    line = await str.ReadLineAsync();
                }
            }
        }
    }
}
