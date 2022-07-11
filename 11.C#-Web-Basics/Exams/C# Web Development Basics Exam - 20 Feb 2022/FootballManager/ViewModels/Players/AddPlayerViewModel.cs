using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels.Players
{
    public class AddPlayerViewModel
    {
        [StringLength(80, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Position { get; set; }

        [Range(0, 10, ErrorMessage = "{0} must be between {1} and {2}")]
        public byte Speed { get; set; }

        [Range(0, 10, ErrorMessage = "{0} must be between {1} and {2}")]
        public byte Endurance { get; set; }

        [StringLength(200, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Description { get; set; }
    }
}