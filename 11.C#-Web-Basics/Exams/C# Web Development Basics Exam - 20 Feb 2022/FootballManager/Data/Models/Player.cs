﻿using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserPlayers = new List<UserPlayer>();
        }

        [StringLength(36)]
        public string Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 5)]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string ImageUrl { get; set; }

        [Required]
        public string Position { get; set; }

        [Range(0, 10)]
        public byte Speed { get; set; }

        [Range(0, 10)]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}