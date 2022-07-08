using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class Product
    {
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Range(0.05, 1000)]
        public decimal? Price { get; set; }

        [StringLength(36)]
        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}