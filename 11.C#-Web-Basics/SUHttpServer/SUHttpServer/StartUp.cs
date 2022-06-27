using SUHttpServer.Server.Responses;

namespace SUHttpServer
{
    public class StartUp
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'> 
Name: <input type='text' name='Name'/> 
Age: <input type='number' name ='Age'/> 
<input type='submit' value ='Save' /> 
</form>";

        public static async Task Main()
            => await new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Hello from the server!"))
                .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
                .MapGet("/HTML", new HtmlResponse(StartUp.HtmlForm))
                .MapPost("/HTML", new TextResponse("")))
            .Start();
    }
}