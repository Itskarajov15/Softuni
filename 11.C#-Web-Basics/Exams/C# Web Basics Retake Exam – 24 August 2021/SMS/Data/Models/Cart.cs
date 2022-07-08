using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new List<Product>();
        }

        [StringLength(36)]
        public string Id { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}