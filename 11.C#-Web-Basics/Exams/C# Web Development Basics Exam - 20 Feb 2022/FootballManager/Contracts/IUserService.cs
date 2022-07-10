using FootballManager.ViewModels;

namespace FootballManager.Contracts
{
    public interface IUserService
    {
        bool Register(RegisterViewModel model);

        string Login(LoginViewModel model);
    }
}