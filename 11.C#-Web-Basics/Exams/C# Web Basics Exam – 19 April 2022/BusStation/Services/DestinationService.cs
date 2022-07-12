using BusStation.Contracts;
using BusStation.Data.Common;
using BusStation.Data.Models;
using BusStation.ViewModels.Destinations;

namespace BusStation.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository repo;

        public DestinationService(IRepository repo)
        {
            this.repo = repo;
        }

        public bool AddDestination(AddDestinationViewModel model)
        {
            var isAdded = false;

            var destination = new Destination()
            {
                DestinationName = model.DestinationName,
                ImageUrl = model.ImageUrl,
                Origin = model.Origin
            };

            destination.Time = model.Date.TimeOfDay.ToString("t");
            destination.Date = model.Date.Date.ToString("d");

            try
            {
                repo.Add(destination);
                repo.SaveChanges();
                isAdded = true;
            }
            catch (Exception)
            {
                isAdded = false;
            }

            return isAdded;
        }

        public IEnumerable<DestinationViewModel> GetAllDestinations()
            => this.repo.All<Destination>()
                        .Select(d => new DestinationViewModel
                        {
                            Id = d.Id,
                            DestinationName = d.DestinationName,
                            Date = d.Date,
                            Time = d.Time,
                            ImageUrl = d.ImageUrl,
                            Origin = d.Origin,
                            TicketsCount = d.Tickets.Count
                        })
                        .ToList();
    }
}