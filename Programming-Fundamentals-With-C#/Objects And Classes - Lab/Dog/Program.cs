using System;

namespace Dog
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog mark = new Dog()
            {
                Age = 5,
                Breed = "corgi",
                Name = "Mark"
            };

            Console.WriteLine($"{mark.Name} is {mark.Breed} and is {mark.Age} years old.");
            mark.Bark();
        }
    }
}
