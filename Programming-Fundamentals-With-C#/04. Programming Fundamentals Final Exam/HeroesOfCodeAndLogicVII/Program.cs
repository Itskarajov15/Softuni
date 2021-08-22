using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> hpOfHeroes = new Dictionary<string, int>();
            Dictionary<string, int> mpOfHeroes = new Dictionary<string, int>();

            int numberOfHeroes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] infoAboutHero = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string hero = infoAboutHero[0];
                int hp = int.Parse(infoAboutHero[1]);
                int mp = int.Parse(infoAboutHero[2]);

                if (hp > 100 || mp > 200)
                {
                    continue;
                }

                if (!hpOfHeroes.ContainsKey(hero))
                {
                    hpOfHeroes.Add(hero, hp);
                    mpOfHeroes.Add(hero, mp);
                }
            }

            string[] commands = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                if (commands[0] == "CastSpell")
                {
                    string hero = commands[1];
                    int mpNeeded = int.Parse(commands[2]);
                    string spellName = commands[3];

                    if (mpOfHeroes[hero] >= mpNeeded)
                    {
                        mpOfHeroes[hero] -= mpNeeded;

                        Console.WriteLine($"{hero} has successfully cast {spellName} and now has {mpOfHeroes[hero]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (commands[0] == "TakeDamage")
                {
                    string hero = commands[1];
                    int damage = int.Parse(commands[2]);
                    string attacker = commands[3];

                    hpOfHeroes[hero] -= damage;

                    if (hpOfHeroes[hero] > 0)
                    {
                        Console.WriteLine($"{hero} was hit for {damage} HP by {attacker} and now has {hpOfHeroes[hero]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero} has been killed by {attacker}!");

                        hpOfHeroes.Remove(hero);
                        mpOfHeroes.Remove(hero);
                    }
                }
                else if (commands[0] == "Recharge")
                {
                    string hero = commands[1];
                    int amount = int.Parse(commands[2]);
                    int recharged = 0;

                    if (mpOfHeroes[hero] + amount > 200)
                    {
                        recharged = 200 - mpOfHeroes[hero];
                        mpOfHeroes[hero] = 200;
                    }
                    else
                    {
                        recharged = amount;
                        mpOfHeroes[hero] += amount;
                    }

                    Console.WriteLine($"{hero} recharged for {recharged} MP!");
                }
                else if (commands[0] == "Heal")
                {
                    string hero = commands[1];
                    int amount = int.Parse(commands[2]);
                    int healed = 0;

                    if (hpOfHeroes[hero] + amount > 100)
                    {
                        healed = 100 - hpOfHeroes[hero];

                        hpOfHeroes[hero] = 100;
                    }
                    else
                    {
                        healed = amount;
                        hpOfHeroes[hero] += amount;
                    }

                    Console.WriteLine($"{hero} healed for {healed} HP!");
                }

                commands = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }

            hpOfHeroes = hpOfHeroes
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var hero in hpOfHeroes)
            {
                string nameOfHero = hero.Key;

                Console.WriteLine(nameOfHero);

                Console.WriteLine($"  HP: {hpOfHeroes[nameOfHero]}");
                Console.WriteLine($"  MP: {mpOfHeroes[nameOfHero]}");
            }
        }
    }
}
