using BusStation.Contracts;
using BusStation.Data.Common;
using BusStation.Data.Models;
using BusStation.ViewModels.Users;
using System.Security.Cryptography;
using System.Text;

namespace BusStation.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
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
            var isValid = false;

            if (this.repo.All<User>().Any(u => u.Username == model.Username) || this.repo.All<User>().Any(u => u.Email == model.Email))
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
                this.repo.Add(user);
                this.repo.SaveChanges();
                isValid = true;
            }
            catch (Exception)
            {
            }

            return isValid;
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