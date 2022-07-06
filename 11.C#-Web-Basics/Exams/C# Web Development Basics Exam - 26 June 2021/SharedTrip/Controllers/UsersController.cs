﻿using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(Request request) 
            : base(request)
        {
        }

        public Response Login()
            => this.View();

        public Response Register()
            => this.View();
    }
}