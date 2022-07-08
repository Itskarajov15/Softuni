using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class User
    {
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [Required]
        [StringLength(36)]
        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}