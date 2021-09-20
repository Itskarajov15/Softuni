using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Guild
{
    public class Player
    {
        public Player(string name, string classType)
        {
            this.Name = name;
            this.Class = classType;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            //"Player {Name}: {Class}
            //Rank: { Rank}
            //Description: { Description}

            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");

            return sb.ToString().TrimEnd();
        }
    }
}
