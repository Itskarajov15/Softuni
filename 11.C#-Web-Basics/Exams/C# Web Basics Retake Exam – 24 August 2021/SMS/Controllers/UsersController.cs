using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request,
            IUserService userService) 
            : base(request)
        {
            this.userService = userService;
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = false });
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isRegistered, error) = userService.Register(model);

            if (isRegistered)
            {
                return Redirect("/Users/Login");
            }

            return View(new { ErrorMessage = error }, "/Error");
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            var (userId, isValid) = userService.IsLoginCorrect(model);

            if (isValid)
            {
                SignIn(userId);

                CookieCollection cookies = new();
                cookies.Add(Session.SessionCookieName, Request.Session.Id);

                return Redirect("/");
            }

            return Redirect("/");
        }
    }
}