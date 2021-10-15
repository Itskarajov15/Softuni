using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                Validator.ThrowIfValueIsInvalid(new HashSet<string> { "white", "wholegrain" }
                , value.ToLower()
                , "Invalid type of dough.");

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                Validator.ThrowIfValueIsInvalid(new HashSet<string> { "crispy", "chewy", "homemade" }
                , value.ToLower()
                , "Invalid type of dough.");

                this.bakingTechnique = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.CheckIfNumberIsInRange(MinWeight, MaxWeight, value, "Dough weight should be in the range [1..200].");

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            var flourTypeModifier = GetFlourModifier();
            var bakingTechniqueModifier = GetBakingTechniqueModifier();

            return this.Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            var bakingTechniqueToLower = this.BakingTechnique.ToLower();

            if (bakingTechniqueToLower == "crispy")
            {
                return 0.9;
            }
            else if (bakingTechniqueToLower == "chewy")
            {
                return 1.1;
            }

            return 1;
        }

        private double GetFlourModifier()
        {
            var flourTypeToLower = this.FlourType.ToLower();

            if (flourTypeToLower == "white")
            {
                return 1.5;
            }

            return 1;
        }
    }
}
