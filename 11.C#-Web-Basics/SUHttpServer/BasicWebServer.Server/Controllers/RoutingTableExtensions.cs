﻿using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;
using System;

namespace BasicWebServer.Server.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable
            , string path
            , Func<TController, Response> controllerFunciton)
            where TController : Controller
            => routingTable.MapGet(path, request => controllerFunciton(CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable
            , string path
            , Func<TController, Response> controllerFunciton)
            where TController : Controller
            => routingTable.MapPost(path, request => controllerFunciton(CreateController<TController>(request)));

        private static TController CreateController<TController>(Request request)
            => (TController)Activator
            .CreateInstance(typeof(TController), new[] { request });
    }
}