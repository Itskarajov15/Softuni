using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BusStation.Contracts;
using BusStation.ViewModels.Tickets;

namespace BusStation.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketsController(
            Request request,
            ITicketService ticketService) 
            : base(request)
        {
            this.ticketService = ticketService;
        }

        public Response Create(int destinationId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return this.View(new { IsAuthenticated = true });
        }

        [HttpPost]
        public Response Create(int destinationId, CreateTicketViewModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            if (model.Price < 10 || model.Price > 90)
            {
                return this.View(new { IsAuthenticated = true });
            }

            if (model.TicketsCount > 10 || model.TicketsCount < 1)
            {
                return this.View(new { IsAuthenticated = true });
            }

            var isCreated = this.ticketService.CreateTicket(model, destinationId);

            if (!isCreated)
            {
                return this.View(new { IsAuthenticated = true });
            }

            return Redirect("/Destinations/All");
        }

        public Response Reserve(int destinationId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var userId = User.Id;
        }
    }
}