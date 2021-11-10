using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Food
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}
