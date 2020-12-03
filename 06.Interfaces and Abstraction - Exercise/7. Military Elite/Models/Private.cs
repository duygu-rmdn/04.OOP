using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }
    }
}
