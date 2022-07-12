using System.ComponentModel.DataAnnotations;

namespace BusStation.Data.Models
{
    public class Destination
    {
        public Destination()
        {
            this.Tickets = new List<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string DestinationName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Origin { get; set; }

        [Required]
        [StringLength(30)]
        public string Date { get; set; }

        [Required]
        [StringLength(30)]
        public string Time { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}