using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, 60, numberOfMedals)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 15;
        }
    }
}
