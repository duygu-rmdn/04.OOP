using System;
using System.Collections.Generic;
using System.Text;

using _03._Shopping_Spree.Common;

namespace _03._Shopping_Spree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ClobalConstants.EMPY_NAME_EXP_MESS);
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value < 0 )
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
