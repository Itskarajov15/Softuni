using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.Oxygen <= 0)
                {
                    continue;
                }

                while (astronaut.Oxygen > 0 && planet.Items.Count > 0)
                {
                    astronaut.Breath();
                    var item = planet.Items.FirstOrDefault();

                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                }
            }
        }
    }
}
