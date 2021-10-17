using System;
using System.Collections.Generic;
using System.Text;

namespace BasicKitchen.Contracts
{
    public interface IOrderable
    {
        void OrderMeal(string mealName);
    }
}
