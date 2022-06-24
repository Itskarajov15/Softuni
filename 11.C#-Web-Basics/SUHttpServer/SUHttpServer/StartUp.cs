using SUHttpServer.Responses;
using System.Net;

namespace SUHttpServer
{
    internal class StartUp
    {
        static async Task Main()
            => await new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Hello from the server!"))
                .MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
                .MapGet("/Redirect", new RedirectResponse("https://softuni.org/")))
            .Start();
    }
}