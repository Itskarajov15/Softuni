﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Vehicle
    {
        public SportCar(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {

        }

        public double MyProperty { get; set; }
        
    }
}
