using BusStation.Data.Models;
using BusStation.ViewModels.Destinations;

namespace BusStation.Contracts
{
    public interface IDestinationService
    {
        IEnumerable<DestinationViewModel> GetAllDestinations();

        bool AddDestination(AddDestinationViewModel model);
    }
}