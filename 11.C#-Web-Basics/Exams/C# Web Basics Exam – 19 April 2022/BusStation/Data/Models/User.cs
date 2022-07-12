using System.ComponentModel.DataAnnotations;

namespace BusStation.Data.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Tickets = new List<Ticket>();
        }

        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}