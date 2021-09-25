using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] stringArray = ArrayCreator.Create(5, "Pesho");

            foreach (var item in stringArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
