using FootballManager.ViewModels.Users;

namespace FootballManager.Contracts
{
    public interface IUserService
    {
        bool Register(RegisterViewModel model);

        string Login(LoginViewModel model);
    }
}