using BusStation.ViewModels.Users;

namespace BusStation.Contracts
{
    public interface IUserService
    {
        bool Register(RegisterViewModel model);

        string Login(LoginViewModel model);
    }
}