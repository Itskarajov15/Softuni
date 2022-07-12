namespace BusStation
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using BusStation.Contracts;
    using BusStation.Data;
    using BusStation.Data.Common;
    using BusStation.Services;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                  .Add<BusStationDbContext>()
                  .Add<IUserService, UserService>()
                  .Add<IRepository, Repository>();
            await server.Start();
        }
    }
}