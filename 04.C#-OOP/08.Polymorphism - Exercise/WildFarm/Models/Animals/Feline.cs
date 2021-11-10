using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public abstract class Feline : Animal
    {
        protected Feline(string name, double weight, string breed) 
            : base(name, weight)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }
    }
}
