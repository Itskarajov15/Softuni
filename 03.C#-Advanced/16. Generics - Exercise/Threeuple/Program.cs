using System;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstThreeupleData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{firstThreeupleData[0]} {firstThreeupleData[1]}";
            string town = firstThreeupleData.Length == 4 ? $"{firstThreeupleData[3]}" 
                : $"{firstThreeupleData[3]} {firstThreeupleData[4]}";
            var firstThreeuple = new CustomThreeuple<string, string, string>(fullName, firstThreeupleData[2], 
                town);
            Console.WriteLine(firstThreeuple);

            var secondThreeupleData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var secondThreeuple = new CustomThreeuple<string, int, bool>(secondThreeupleData[0],
                int.Parse(secondThreeupleData[1]), secondThreeupleData[2] == "drunk" ? true : false);
            Console.WriteLine(secondThreeuple);

            var thirdThreeupleData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var thirdThreeuple = new CustomThreeuple<string, double, string>(thirdThreeupleData[0],
                double.Parse(thirdThreeupleData[1]), thirdThreeupleData[2]);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
