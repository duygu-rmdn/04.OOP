using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private static Bag bag;
        private string name;
        public Warrior(string name) 
            : base(name, 100, 50, 40, bag)
        {
            bag = new Satchel();
            characters = new List<Character>();
        }
        private readonly ICollection<Character> characters;
        public void Attack(Character character)
        {
            Character attacer = characters.FirstOrDefault(x => x.Name == name);
            if (attacer.IsAlive && character.IsAlive)
            {

            if (name == character.GetType().Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            character.TakeDamage(attacer.AbilityPoints);
            }

        }
    }
}
