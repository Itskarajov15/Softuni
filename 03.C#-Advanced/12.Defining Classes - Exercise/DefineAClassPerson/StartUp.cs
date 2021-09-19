using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var personOne = new Person();

            personOne.Name = "Pesho";
            personOne.Age = 20;

            var personTwo = new Person() {
                Name = "Peter",
                Age = 21 
            };
        }
    }
}
