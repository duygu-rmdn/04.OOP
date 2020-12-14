using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capasity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private int reserved;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
        }

        private ICollection<IBakedFood> FoodOrders;

        private ICollection<IDrink> DrinkOrders;


        public int TableNumber { get; }

        public int Capacity
        {
            get => this.capasity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capasity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson
        {
            get => this.pricePerPerson;
            private set
            {
                this.pricePerPerson = value;
            }
        }

        public bool IsReserved => reserved == capasity;



        decimal ITable.Price => pricePerPerson * numberOfPeople;

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            reserved = 0;
            numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return (FoodOrders.Count + DrinkOrders.Count) * pricePerPerson * numberOfPeople; 
        }

        public string GetFreeTableInfo()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {this.capasity}");
            sb.AppendLine($"Price per Person: {this.pricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            reserved += numberOfPeople;
        }
    }
}
