using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private static Bag bag;
        private readonly ICollection<Character> characters;
        private string name;
       

        public Priest(string name)
            : base(name, 50, 25, 40, bag)
        {
            bag = new Backpack();
            characters = new List<Character>();
        }

        public void Heal(Character character)
        {
            Character attacer = characters.FirstOrDefault(x => x.Name == name);
            if (attacer.IsAlive && character.IsAlive)
            {
                character.Health += attacer.AbilityPoints;
               
                
            }
            else
            {
                throw new ArgumentException($"{attacer} не може да излекува!");
            }
        }
    }
}
