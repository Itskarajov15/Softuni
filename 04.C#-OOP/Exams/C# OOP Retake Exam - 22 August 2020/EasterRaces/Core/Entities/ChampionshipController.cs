using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<ICar> cars;
        private IRepository<IDriver> drivers;
        private IRepository<IRace> races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (this.drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (this.cars.GetByName(carModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            IDriver driver = this.drivers.GetByName(driverName);
            ICar car = this.cars.GetByName(carModel);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driver.Name, car.Model);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (this.drivers.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (this.races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driver = this.drivers.GetByName(driverName);
            IRace race = this.races.GetByName(raceName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (this.cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            this.cars.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (this.drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            this.drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driver.Name);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);

            this.races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (this.races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = this.races.GetByName(raceName);

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var winners = this.drivers
                .GetAll()
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .ToList();

            var sb = new StringBuilder();

            sb.AppendLine($"Driver {winners[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {winners[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {winners[2].Name} is third in {race.Name} race.");

            this.races.Remove(race);    

            return sb.ToString().TrimEnd();
        }
    }
}
