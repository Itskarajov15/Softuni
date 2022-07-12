using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BusStation.Contracts;
using BusStation.ViewModels.Destinations;

namespace BusStation.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationService destinationService;

        public DestinationsController(
            Request request,
            IDestinationService destinationService) 
            : base(request)
        {
            this.destinationService = destinationService;
        }

        public Response All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var destinations = this.destinationService.GetAllDestinations();

            var model = new
            {
                Destinations = destinations,
                IsAuthenticated = true
            };

            return this.View(model);
        }

        public Response Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return this.View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddDestinationViewModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            if (String.IsNullOrEmpty(model.DestinationName) || model.DestinationName.Length < 2 || model.DestinationName.Length > 50)
            {
                return this.View(new { IsAuthenticated = true });
            }

            if (String.IsNullOrEmpty(model.Origin) || model.Origin.Length < 2 || model.Origin.Length > 50)
            {
                return this.View(new { IsAuthenticated = true });
            }

            if (DateTime.Compare(model.Date, DateTime.UtcNow) < 0)
            {
                return this.View(new { IsAuthenticated = true });
            }

            if (String.IsNullOrEmpty(model.ImageUrl))
            {
                return this.View(new { IsAuthenticated = true });
            }

            var isAdded = this.destinationService.AddDestination(model);

            if (!isAdded)
            {
                return this.View(new { IsAuthenticated = true });
            }

            return Redirect("/Destinations/All");
        }
    }
}