using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayInputModel
    {
        [XmlElement("Title")]
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Range(typeof(float), "0.00", "10.00")]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [MaxLength(700)]
        [Required]
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Screenwriter { get; set; }
    }
}