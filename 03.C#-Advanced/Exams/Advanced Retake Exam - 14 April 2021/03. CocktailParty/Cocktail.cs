using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel
        {
            get { return this.Ingredients.Sum(x => x.Alcohol); }
        }

        public void Add(Ingredient ingredient)
        {
            var isInTheList = Ingredients.Any(x => x.Name == ingredient.Name);
            var isEnoughAlcohol = ingredient.Alcohol <= this.MaxAlcoholLevel;

            if (!isInTheList && isEnoughAlcohol)
            {
                this.Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            return Ingredients.Remove(Ingredients.Find(x => x.Name == name));
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.Find(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var ingredient in this.Ingredients)
            {
                sb.AppendLine($"{ingredient}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
