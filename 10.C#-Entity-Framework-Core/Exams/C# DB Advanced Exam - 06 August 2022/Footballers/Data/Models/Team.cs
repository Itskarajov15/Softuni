﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        public int Trophies { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}