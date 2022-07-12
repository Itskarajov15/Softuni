namespace BusStation.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    public class HomeController : Controller
    {
        public HomeController(Request request)
          : base(request)
        {
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Destinations/All");
            }

            return this.View(new { IsAuthenticated = false });
        }
    }
}
