using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroFactory = new HeroFactory();

            var heroes = new List<BaseHero>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var heroType = Console.ReadLine();

                try
                {
                    var hero = heroFactory.CreateHero(name, heroType);
                    heroes.Add(hero);
                }
                catch (ArgumentException ex)
                {
                    i -= 1;
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            var powerOfBoss = int.Parse(Console.ReadLine());

            var powerOfAllHeroes = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                powerOfAllHeroes += hero.Power;
            }

            if (powerOfAllHeroes >= powerOfBoss)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
