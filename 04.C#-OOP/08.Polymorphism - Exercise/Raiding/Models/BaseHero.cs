using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public virtual int Power { get; set; }

        public abstract string CastAbility();
    }
}
