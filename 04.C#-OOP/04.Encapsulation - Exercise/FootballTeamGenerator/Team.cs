using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            if (this.players.Exists(p => p.Name == name))
            {
                this.players.Remove(this.players.Find(p => p.Name == name));
            }
            else
            {
                throw new InvalidOperationException($"Player {name} is not in {this.Name} team.");
            }
        }

        public string GetRating()
        {
            return $"{this.Name} - {Math.Round(this.players.Sum(p => p.GetOverallSkilLevel()), MidpointRounding.AwayFromZero)}";
        }
    }
}
