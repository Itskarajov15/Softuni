using BusStation.Contracts;
using BusStation.Data.Common;
using BusStation.Data.Models;
using BusStation.ViewModels.Tickets;

namespace BusStation.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository repo;

        public TicketService(IRepository repo)
        {
            this.repo = repo;
        }

        public bool CreateTicket(CreateTicketViewModel model, int destinationId)
        {
            var isCorrect = false;

            for (int i = 0; i < model.TicketsCount; i++)
            {
                var ticket = new Ticket()
                {
                    Price = model.Price,
                    DestinationId = destinationId
                };

                try
                {
                    this.repo.Add(ticket);
                    this.repo.SaveChanges();
                    isCorrect = true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return isCorrect;
        }

        public bool ReserveTicker(int destinationId, string userId)
        {
            var user = this.repo.All<User>()
                                .Where(u => u.Id == userId)
                                .FirstOrDefault();

            user.Tickets.Add(new Ticket()
            {
                DestinationId = destinationId
            });
        }
    }
}