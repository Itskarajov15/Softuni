using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Person : ICitizen
    {
        public Person(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }
}
