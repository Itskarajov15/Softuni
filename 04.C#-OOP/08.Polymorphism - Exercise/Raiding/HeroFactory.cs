using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class HeroFactory
    {
        public BaseHero CreateHero(string name, string type)
        {
            if (type == nameof(Druid))
            {
                return new Druid(name);
            }
            else if (type == nameof(Paladin))
            {
                return new Paladin(name);
            }
            else if (type == nameof(Rogue))
            {
                return new Rogue(name);
            }
            else if (type == nameof(Warrior))
            {
                return new Warrior(name);
            }
            else
            {
                return null;
            }
        }
    }
}
