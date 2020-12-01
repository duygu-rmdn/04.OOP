using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using _03._Shopping_Spree.Common;

namespace _03._Shopping_Spree.Models
{
    public class Person
    {
        private const string NOT_ENOUGH_MONEY_MSG = "{0}can't afford {1}";
        private const string BOUGHT_MSG = "{0} bought {1}";
        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }
        public string Name {
            get 
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ClobalConstants.EMPY_NAME_EXP_MESS);
                }
                this.name = value;
            }
        }

        public decimal Money {
            get 
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ClobalConstants.NEGATIVE_MONEY_EXP_MESS);
                }
                this.money = value;
            } 
        }

        public IReadOnlyCollection<Product> Bag 
        { 
            get
            {
                return (IReadOnlyCollection<Product>)this.bag;
            }
            
        }

        public string BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return string.Format(NOT_ENOUGH_MONEY_MSG, this.Name, product.Name);
            }
            this.Money -= product.Cost;
            this.bag.Add(product);
            return string.Format(BOUGHT_MSG, this.Name, product.Name);
        }

        public override string ToString()
        {
            string productOutput = this.Bag.Count > 0 ? string.Join(", ", this.Bag) : "Nothing bought";

            return $"{this.Name} - {productOutput}";
        }
    }
}
