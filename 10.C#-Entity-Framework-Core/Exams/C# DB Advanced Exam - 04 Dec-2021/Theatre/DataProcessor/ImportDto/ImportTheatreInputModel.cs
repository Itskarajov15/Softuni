using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; }

        [Range(typeof(sbyte), "1", "10")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Director { get; set; }

        public ICollection<ImportTicketInputModel> Tickets { get; set; }
    }
}