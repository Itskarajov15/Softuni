using BusStation.ViewModels.Tickets;

namespace BusStation.Contracts
{
    public interface ITicketService
    {
        bool CreateTicket(CreateTicketViewModel model, int destinationId);

        bool ReserveTicker(int destinationId, string userId);
    }
}