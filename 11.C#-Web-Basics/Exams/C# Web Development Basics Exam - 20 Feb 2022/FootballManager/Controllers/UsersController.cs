using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request, IUserService usersService)
               : base(request)
        {
            this.userService = usersService;

        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            var userId = userService.Login(model);

            if (userId == null)
            {
                return View(new { IsAuthenticated = false });
            }

            SignIn(userId);

            CookieCollection cookies = new();
            cookies.Add(Session.SessionCookieName,
                Request.Session.Id);

            return Redirect("/Players/All");
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var isValid = userService.Register(model);

            if (isValid)
            {
                return Redirect("/Users/Login");
            }

            return this.View(new { IsAuthenticated = false });
        }
    }
}