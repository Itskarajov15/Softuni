using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core.Contracts
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;

            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }

            this.cars.Add(car);

            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer = null;
            ICar car = this.cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }

            this.racers.Add(racer);

            return $"Successfully added racer {racer.Username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            var sortedRacers = this.racers
                .Models
                .OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username)
                .ToList();

            foreach (var racer in sortedRacers)
            {
                //"{racer type}: {racer username}"
                //"--Driving behavior: {racingBehavior}"
                //"--Driving experience: {drivingExperience}"
                //"--Car: {carMake} {carModel} ({carVIN})"

                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
