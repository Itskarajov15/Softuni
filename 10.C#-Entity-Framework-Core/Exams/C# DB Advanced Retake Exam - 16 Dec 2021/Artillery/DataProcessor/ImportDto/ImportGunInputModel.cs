using Artillery.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportGunInputModel
    {
        public int ManufacturerId { get; set; }

        [Range(100, 1_350_000)]
        public int GunWeight { get; set; }

        [Range(2.00, 35.00)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Range(1, 100_000)]
        public int Range { get; set; }

        [EnumDataType(typeof(GunType))]
        [Required]
        public string GunType { get; set; }

        public int ShellId { get; set; }

        public ICollection<ImportCountryGunInputModel> Countries { get; set; }
    }
}