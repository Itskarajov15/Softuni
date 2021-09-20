using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Roster = new List<Player>();
        }

        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return this.Roster.Count; }
        }

        public void AddPlayer(Player player)
        {
            if (this.Roster.Count < this.Capacity)
            {
                this.Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return Roster.Remove(Roster.Find(x => x.Name == name));
        }

        public void PromotePlayer(string name)
        {
            var player = Roster.Find(x => x.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var player = Roster.First(x => x.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classType)
        {
            var array = Roster
                .Where(x => x.Class == classType)
                .ToArray();

            Roster = Roster
                .Where(x => x.Class != classType)
                .ToList();

            return array;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.Roster)
            {
                sb.AppendLine($"{player}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
