using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels.Users
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} must to be valid")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password and ConfirmPassword must be equal")]
        public string ConfirmPassword { get; set; }
    }
}