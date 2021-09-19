using System;
using System.Collections.Generic;
using System.Text;

namespace Dog
{
    class Dog
    {
        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public void Bark()
        {
            Console.WriteLine("Бау");
        }
    }
}
