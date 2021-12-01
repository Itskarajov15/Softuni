using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies;

        public BunnyRepository()
        {
            this.bunnies = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.bunnies.AsReadOnly();

        public void Add(IBunny model)
            => this.bunnies.Add(model);

        public IBunny FindByName(string name)
            => this.bunnies.FirstOrDefault(b => b.Name == name);

        public bool Remove(IBunny model)
            => this.bunnies.Remove(model);
    }
}
