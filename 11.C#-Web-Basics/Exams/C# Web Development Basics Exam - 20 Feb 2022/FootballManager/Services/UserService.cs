using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Users;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public UserService(
            IRepository repo,
            IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public string Login(LoginViewModel model)
        {
            var user = this.repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == HashPassword(model.Password))
                .SingleOrDefault();

            return user?.Id;
        }

        public bool Register(RegisterViewModel model)
        {
            var registered = false;
            var isValid = validationService.ValidateModel(model);

            if (!isValid)
            {
                return isValid;
            }

            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashPassword(model.Password)
            };

            try
            {
                repo.Add<User>(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
            }

            return registered;
        }

        private string HashPassword(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }
    }
}