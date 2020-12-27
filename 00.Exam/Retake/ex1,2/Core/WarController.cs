using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly ICollection<Character> party;
		private readonly ICollection<Item> pool;
		private readonly ICollection<Bag> bag;
		private Character charecter;
		private Item item;
		

		public WarController()
		{
			party = new List<Character>();
			pool = new List<Item>();
			bag = new List<Bag>();
		}
		
		public string JoinParty(string[] args)
		{
			
			string characterType = args[0];
			string name = args[1];
			if (characterType == "Priest")
			{
				charecter = new Priest(name);
			}
			else if(characterType == "Warrior")
			{
				charecter = new Warrior(name);
			}
            else
            {
				throw new ArgumentException($"Invalid character type \"{0}\"!", characterType);
            }
			party.Add(charecter);
			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

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
				throw new ArgumentException($"Invalid item \"{0}\"!", itemName);
            }
			pool.Add(item);
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			charecter = party.FirstOrDefault(x => x.Name == characterName);
            if (charecter == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
            }
            if (pool.Count == 0)
            {
				throw new InvalidOperationException($"No items left in pool!");
            }
			charecter.Bag.AddItem(pool.Last());
			return $"{characterName} picked up {pool.Last()}!";
		}
		

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			charecter = party.FirstOrDefault(x => x.Name == characterName);
			item = pool.FirstOrDefault(x => x.GetType().Name == itemName);
            if (charecter == null)
            {
				throw new ArgumentException($"Character {characterName} not found!");
			}
			charecter.Bag.Remove(item);
			return $"{characterName} used {itemName}.";
		}

		public string GetStats()
		{
			var sortedParty = party.OrderByDescending(x => x.IsAlive).ThenByDescending(x=>x.Health);
			StringBuilder sb = new StringBuilder();
            foreach (var chars in sortedParty)
            {
				string all = "";
                //Alive/Dead
                if (chars.IsAlive)
                {
					all += "Alive";
				}
                else
                {
					all += "Dead";
				}
				sb.AppendLine($"{chars.Name} - HP: {chars.Health}/{chars.BaseHealth}, AP: {chars.Armor}/{chars.BaseAmour}, Status: {all}");
            }
			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args  )
		{
			string attackerName = args[0];
			string receiverName = args[1];
			Character attacher = party.FirstOrDefault(x => x.Name == attackerName);
			Character receiver = party.FirstOrDefault(x => x.Name == receiverName);
			if (attacher == null)
            {
				throw new ArgumentException($"Character {attackerName} not found!");
            }
			if (receiver == null)
			{
				throw new ArgumentException($"Character {receiverName} not found!");
			}
			Warrior warrior = (Warrior)attacher;
			warrior.Attack(receiver);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{attackerName} attacks {receiverName} for {warrior.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseAmour} AP left!");

            if (!receiver.IsAlive)
            {
				sb.AppendLine($"{receiver.Name} is dead!");
            }
			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];
			Character healer = party.FirstOrDefault(x => x.Name == healerName);
			Character healingReceiver = party.FirstOrDefault(x => x.Name == healingReceiverName);
			if (healer == null)
			{
				throw new ArgumentException($"Character {healerName} not found!");
			}
			if (healingReceiver == null)
			{
				throw new ArgumentException($"Character {healingReceiverName} not found!");
			}
			Priest priest = (Priest)healer;
			priest.Heal(healingReceiver);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{healerName} heals {healingReceiverName} for {healer.AbilityPoints}! {healingReceiverName} has {healingReceiver.Health} health now!");

			return sb.ToString().TrimEnd();
		}
	}
}
