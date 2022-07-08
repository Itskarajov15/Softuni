using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository repo;

        public TripService(IRepository repo)
        {
            this.repo = repo;
        }

        public void AddTrip(TripViewModel model)
        {
            Trip trip = new Trip()
            {
                Description = model.Description,
                EndPoint = model.EndPoint,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                StartPoint = model.StartPoint
            };

            DateTime date;

            DateTime.TryParseExact(model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date);

            trip.DepartureTime = date;

            repo.Add(trip);
            repo.SaveChanges();
        }

        public void AddUserToTrip(string tripId, string id)
        {
            var user = repo.All<User>()
                .FirstOrDefault(u => u.Id == id);

            var trip = repo.All<Trip>()
                .FirstOrDefault(t => t.Id == tripId);

            if (user == null || trip == null)
            {
                throw new ArgumentException("User or trip not found");
            }

            user.UserTrips.Add(new UserTrip() 
            { 
                TripId = tripId,
                Trip = trip,
                User = user,
                UserId = id
            });

            repo.SaveChanges();
        }

        public IEnumerable<TripListViewModel> GetAllTrips()
        {
            return repo.All<Trip>()
                .Select(t => new TripListViewModel
                {
                    Id = t.Id,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    EndPoint = t.EndPoint,
                    StartPoint = t.StartPoint,
                    Seats = t.Seats
                })
                .ToList();
        }

        public TripDetailsViewModel GetTripDetails(string tripId)
            => repo.All<Trip>()
                    .Where(t => t.Id == tripId)
                    .Select(t => new TripDetailsViewModel
                    {
                        Id = t.Id,
                        DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                        EndPoint = t.EndPoint,
                        StartPoint = t.StartPoint,
                        Seats = t.Seats,
                        Description = t.Description,
                        ImagePath = t.ImagePath
                    })
                    .FirstOrDefault();

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(TripViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new();
            DateTime date;

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("StartPoint is required"));
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("EndPoint is required"));
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 80)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Description is required and must not be more than 80 characters long"));
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Seats must be between 2 and 6"));
            }

            if (!DateTime.TryParseExact(model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("DepartureTime is incorrect"));
            }

            return (isValid, errors);
        }
    }
}