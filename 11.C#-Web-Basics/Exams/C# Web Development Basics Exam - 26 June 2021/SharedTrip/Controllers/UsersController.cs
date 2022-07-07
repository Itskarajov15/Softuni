using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.Users;
using System;
using System.Collections.Generic;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(
            Request request,
            IUserService userService) 
            : base(request)
        {
            this.userService = userService;
        }

        public Response Login()
            => this.View();

        public Response Register()
            => this.View();

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isValid, errors) = userService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                userService.RegisterUser(model);
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Users/Login");
        }
    }
}