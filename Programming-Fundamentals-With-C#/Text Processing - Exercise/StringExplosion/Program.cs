using System;
using System.Text;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int powerOfExplosion = 0;

            //abv>1>1>2>2asdasd

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    powerOfExplosion += int.Parse(input[i + 1].ToString());
                }

                if (powerOfExplosion == 0)
                {
                    result.Append(input[i]);
                }
                else
                {
                    if (input[i] != '>')
                    {
                        powerOfExplosion -= 1;
                    }
                    else
                    {
                        result.Append(input[i]);
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
