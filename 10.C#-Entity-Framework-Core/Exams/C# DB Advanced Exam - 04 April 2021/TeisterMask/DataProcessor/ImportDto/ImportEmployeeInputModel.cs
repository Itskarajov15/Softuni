using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeInputModel
    {
        [Required]
        [RegularExpression("^[A-Za-z0-9]+$")]
        [StringLength(40, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{3}-[\d]{3}-[\d]{4}$")]
        public string Phone { get; set; }

        public List<int> Tasks { get; set; }
    }
}