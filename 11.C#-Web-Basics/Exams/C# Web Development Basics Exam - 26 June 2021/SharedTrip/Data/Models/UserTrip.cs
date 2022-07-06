using System.ComponentModel.DataAnnotations.Schema;

namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(TripId))]
        public string TripId { get; set; }

        public Trip Trip { get; set; }
    }
}