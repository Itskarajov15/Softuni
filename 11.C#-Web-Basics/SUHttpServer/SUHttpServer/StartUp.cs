using System.Net;

namespace SUHttpServer
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            var ipAddress = "127.0.0.1";
            var port = 8080;

            var server = new HttpServer(ipAddress, port);
            await server.Start();
        }
    }
}