using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Contracts
{
    public abstract class Bag : IBag
    {
        private int capasity = 100;

        private readonly ICollection<Item> items;
        private readonly ICollection<Item> bag;

        private Item item;

        public Bag()
        {
            items = new List<Item>();
            bag = new List<Item>();
        }

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
        }
        public int Capacity
        {
            get => this.capasity;
            set => this.capasity = value;
        }
        private int Calculate()
        {
            int sum = 0;
            foreach (var item in items)
            {
                sum += item.Weight;
            }
            return sum;
        }

        public int Load
        => Calculate();

        public IReadOnlyCollection<Item> Items
            => (IReadOnlyCollection<Item>)items;

        public void AddItem(Item item)
        {
            if (Load + item.Weight > capasity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            bag.Add(item);
        }

        public Item GetItem(string name)
        {
            if (bag.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            item = bag.FirstOrDefault(x => x.GetType().Name == name);
            if (!bag.Contains(item))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            bag.Remove(item);
            return item;
        }
        public void Remove(Item itemToRemove)
        {
            bag.Remove(itemToRemove);
        }
    }
}
