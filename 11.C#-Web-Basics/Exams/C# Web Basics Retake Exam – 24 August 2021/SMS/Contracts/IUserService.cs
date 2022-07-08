using SMS.Models;

namespace SMS.Contracts
{
    public interface IUserService
    {
        (bool registered, string error) Register(RegisterViewModel model);

        (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model)
    }
}