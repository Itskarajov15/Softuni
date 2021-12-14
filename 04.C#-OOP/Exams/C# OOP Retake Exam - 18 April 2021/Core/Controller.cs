using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IBunny> bunnyRepository;
        private IRepository<IEgg> eggRepository;
        private IWorkshop workshop;

        public Controller()
        {
            this.bunnyRepository = new BunnyRepository();
            this.eggRepository = new EggRepository();
            this.workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            this.bunnyRepository.Add(bunny);

            var result = string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);

            return result;
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            if (this.bunnyRepository.FindByName(bunnyName) == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);

            IBunny bunny = this.bunnyRepository.FindByName(bunnyName);

            bunny.AddDye(dye);

            var result = string.Format(OutputMessages.DyeAdded, power, bunnyName);

            return result;
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggRepository.Add(egg);

            var result = string.Format(OutputMessages.EggAdded, eggName);

            return result;
        }

        public string ColorEgg(string eggName)
        {
            var bunnies = this.bunnyRepository
                .Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            IEgg egg = this.eggRepository.FindByName(eggName);

            if (bunnies.Count <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            while (bunnies.Count > 0 && !egg.IsDone())
            {
                var bunny = bunnies.FirstOrDefault();

                this.workshop.Color(egg, bunny);

                if (bunny.Energy <= 0 || bunny.Dyes.Count <= 0)
                {
                    bunnies.Remove(bunny);
                }
            }


            if (egg.IsDone())
            {
                return string.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            var sb = new StringBuilder();

            var coloredEggs = this.eggRepository
                .Models
                .Where(e => e.IsDone())
                .ToList();

            sb.AppendLine($"{coloredEggs.Count} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in this.bunnyRepository.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
