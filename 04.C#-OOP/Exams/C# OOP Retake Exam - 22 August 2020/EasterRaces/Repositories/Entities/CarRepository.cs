using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public void Add(ICar model)
            => this.models.Add(model);

        public IReadOnlyCollection<ICar> GetAll()
            => this.models.AsReadOnly();

        public ICar GetByName(string name)
            => this.models.FirstOrDefault(m => m.Model == name);

        public bool Remove(ICar model)
            => this.models.Remove(this.models.FirstOrDefault(m => m.Model == model.Model));
    }
}
