using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		// TODO: Implement the rest of the class.
		private string name;
		private double baseHealth;
		private double health;
		private double amour;
		private double baseAmour;

		private Character character;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			this.Name = name;
			this.Health = health;
			this.Armor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
        }

		public string Name
        {
			get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException("Name cannot be null or whitespace!");

				}
				this.name = value;
            }
        }

		public double BaseHealth 
		{
			get
			=> this.baseHealth;
			private set
            {
				this.baseHealth = value;
            }
		}
		public double Health  
		{
			get
			=> this.health;
			 set
			{
				this.health = baseHealth;
			}
		}
		
		public double Armor
        {
			get
			=> this.amour;
			private set
			{
				this.amour = value;
			}
		}
		public double BaseAmour
		{
			get { return this.baseAmour; } private set { baseAmour = this.amour; }
		}

		public double AbilityPoints { get; private set; }

		public Bag Bag { get; private set; }


		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
        {
            if (IsAlive == true)
            {
                if (Armor > hitPoints)
                {
					Armor -= hitPoints;
				}
                else
                {
					Armor = 0;
					hitPoints -= Armor;
					Health -= hitPoints;
                    if (Health <= 0)
                    {
						IsAlive = false;
                    }
                }
            }

        }

		public void UseItem(Item item)
        {
            if (IsAlive == true)
            {
				item.AffectCharacter(character);
            }
        }
	}
}