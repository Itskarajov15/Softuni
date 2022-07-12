using System.ComponentModel.DataAnnotations;

namespace BusStation.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Range(10, 90)]
        public decimal Price { get; set; }

        public string UserId { get; set; }

        public int DestinationId { get; set; }
    }
}