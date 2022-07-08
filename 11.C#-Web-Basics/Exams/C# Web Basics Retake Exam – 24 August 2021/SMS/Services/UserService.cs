using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public (bool registered, string error) Register(RegisterViewModel model)
        {
            bool registered = false;
            string error = null;
            var (isValid, validationError) = ValidateRegisterModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            Cart cart = new Cart();

            User user = new User()
            {
                Username = model.Username,
                Password = CalculateHash(model.Password),
                Email = model.Email,
                Cart = cart,
                CartId = cart.Id
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error = "Could not save user in database";
            }

            return (registered, error);
        }

        public (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model)
        {
            bool isCorrect = false;
            string userId = String.Empty;

            var user = GetUserByUsername(model.Username);

            if (user != null)
            {
                isCorrect = user.Password == CalculateHash(model.Password);
            }

            if (isCorrect)
            {
                userId = user.Id;
            }

            return (userId, isCorrect);
        }

        private string CalculateHash(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }

        private (bool isValid, string error) ValidateRegisterModel(RegisterViewModel model)
        {
            bool isValid = true;
            var error = new StringBuilder();

            if (model == null)
            {
                return (false, "Register model is required");
            }

            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 5 || model.Username.Length > 20)
            {
                isValid = false;
                error.AppendLine("Username must be between 5 and 20 characters");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                isValid = false;
                error.AppendLine("Email must be valid");
            }

            if (string.IsNullOrEmpty(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                isValid = false;
                error.AppendLine("Password must be between 6 and 20 characters");
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                error.AppendLine("Password and ConfirmPassword do not match");
            }

            return (isValid, error.ToString().TrimEnd());
        }

        private User GetUserByUsername(string username)
            => this.repo.All<User>()
                .FirstOrDefault(u => u.Username == username);
    }
}