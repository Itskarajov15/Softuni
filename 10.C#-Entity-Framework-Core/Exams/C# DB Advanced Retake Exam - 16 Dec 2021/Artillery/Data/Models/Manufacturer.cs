using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Guns = new HashSet<Gun>();
        }

        public int Id { get; set; }

        [Required]
        public string ManufacturerName { get; set; }

        [Required]
        public string Founded { get; set; }

        public ICollection<Gun> Guns { get; set; }
    }
}