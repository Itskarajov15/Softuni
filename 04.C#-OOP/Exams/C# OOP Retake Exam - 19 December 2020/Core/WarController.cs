using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> characters;
		private List<Item> items;

		public WarController()
		{
			this.characters = new List<Character>();
			this.items = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			var characterType = args[0];
			var name = args[1];

			Character character = null;

            if (characterType == "Priest")
            {
				character = new Priest(name);
            }
            else if (characterType == "Warrior")
            {
				character = new Warrior(name);
			}
			else
            {
				throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

			this.characters.Add(character);

			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			var itemName = args[0];

			Item item = null;

            if (itemName == "FirePotion")
            {
				item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
				item = new HealthPotion();
            }
			else
            {
				throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

			this.items.Add(item);

			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			var characterName = args[0];

			Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.items.Count <= 0)
            {
				throw new InvalidOperationException("No items left in pool!");
            }

			Item item = this.items[this.items.Count - 1];

			this.items.Remove(item);

			character.Bag.AddItem(item);

			return $"{characterName} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			var characterName  = args[0];
			var itemName = args[1];

			Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
            }

			Item item = character.Bag.GetItem(itemName);

			character.UseItem(item);

			return $"{character.Name} used {itemName}.";
		}

		public string GetStats()
		{
			var sortedCharacters = this.characters
				.OrderByDescending(c => c.IsAlive)
				.ThenByDescending(c => c.Health)
				.ToList();

			var sb = new StringBuilder();

            foreach (var character in sortedCharacters)
            {
				var status = String.Empty;

                if (character.IsAlive)
                {
					status = "Alive";
                }
				else
                {
					status = "Dead";
                }

				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			var attackerName = args[0];
			var receiverName = args[1];

			Character attacker = this.characters.FirstOrDefault(c => c.Name == attackerName);
			Character receiver = this.characters.FirstOrDefault(c => c.Name == receiverName);

            if (attacker == null)
            {
				throw new ArgumentException($"Character {attackerName} not found!");
			}
            else if (receiver == null)
            {
				throw new ArgumentException($"Character {receiverName} not found!");
			}

			Warrior warrior = attacker as Warrior;

            if (warrior == null)
            {
				throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

			warrior.Attack(receiver);

			var sb = new StringBuilder();

			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has " +
				$"{receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
				sb.AppendLine($"{receiver.Name} is dead!");
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			var healerName = args[0];
			var healingReceiverName = args[1];

			Character healer = this.characters.FirstOrDefault(c => c.Name == healerName);
			Character receiver = this.characters.FirstOrDefault(c => c.Name == healingReceiverName);

            if (healer == null)
            {
				throw new ArgumentException($"Character {healerName} not found!");
			}
            else if (receiver == null)
            {
				throw new ArgumentException($"Character {healerName} not found!");
			}

			Priest priest = healer as Priest;

            if (priest == null)
            {
				throw new ArgumentException($"{healerName} cannot heal!");
            }

			priest.Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
