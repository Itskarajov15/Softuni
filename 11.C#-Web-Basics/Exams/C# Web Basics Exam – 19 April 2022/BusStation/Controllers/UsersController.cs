using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BusStation.Contracts;
using BusStation.ViewModels.Users;

namespace BusStation.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(
            Request request,
            IUserService userService) 
            : base(request)
        {
            this.userService = userService;
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("Destinations/All");
            }

            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            if (User.IsAuthenticated)
            {
                return Redirect("Destinations/All");
            }

            if (String.IsNullOrEmpty(model.Username) || model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.View(new { IsAuthenticated = false });
            }

            if (String.IsNullOrEmpty(model.Email) || model.Email.Length < 10 || model.Email.Length > 60)
            {
                return this.View(new { IsAuthenticated = false });
            }

            if (String.IsNullOrEmpty(model.Password) || model.Password.Length < 5 || model.Password.Length > 20)
            {
                return this.View(new { IsAuthenticated = false });
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.View(new { IsAuthenticated = false });
            }

            var isRegisterd = this.userService.Register(model);

            if (!isRegisterd)
            {
                return this.View(new { IsAuthenticated = false });
            }

            return Redirect("/Users/Login");
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Destinations/All");
            }

            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Destinations/All");
            }

            var userId = this.userService.Login(model);

            if (userId == null)
            {
                return this.View(new { IsAuthenticated = false });
            }

            SignIn(userId);

            CookieCollection cookies = new();
            cookies.Add(Session.SessionCookieName,
                Request.Session.Id);

            return Redirect("/Destinations/All");
        }
    }
}