using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            var sb = new StringBuilder();

            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                sb.AppendLine($"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!");
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                sb.AppendLine($"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!");
            }
            else if(!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                sb.AppendLine("Race cannot be completed because both racers are not available!");
            }
            else
            {
                racerOne.Race();
                racerTwo.Race();

                var racerOneWinningChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * (racerOne.RacingBehavior == "strict" ? 1.2 : 1.1);
                var racerTwoWinningChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * (racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1);

                if (racerOneWinningChance > racerTwoWinningChance)
                {
                    sb.AppendLine($"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!");
                }
                else
                {
                    sb.AppendLine($"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
