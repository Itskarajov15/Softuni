using System;
using System.Linq;

namespace ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[] command = Console.ReadLine()
                .Split();

            while (command[0] != "end")
            {
                if (command[0] == "swap")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);

                    array = SwapTwoElementsInTheArray(array, firstIndex, secondIndex);
                }
                else if (command[0] == "multiply")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);

                    array = MultiplyTwoElementsInTheArray(array, firstIndex, secondIndex);
                }
                else if (command[0] == "decrease")
                {
                    array = DecreaseAllTheElementsWithOne(array);
                }

                command = Console.ReadLine()
                .Split();
            }

            Console.WriteLine(String.Join(", ", array));
        }

        static int[] DecreaseAllTheElementsWithOne(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] -= 1;
            }

            return array;
        }

        static int[] MultiplyTwoElementsInTheArray(int[] array, int firstIndex, int secondIndex)
        {
            int result = array[firstIndex] * array[secondIndex];

            array[firstIndex] = result;

            return array;
        }

        static int[] SwapTwoElementsInTheArray(int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;

            return array;
        }
    }
}
