using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, 50, numberOfMedals)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;
        }
    }
}
