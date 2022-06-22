using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SUHttpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var port = 8080;

            var server = new HttpServer("127.0.0.1", port);
            server.Start();
        }
    }
}