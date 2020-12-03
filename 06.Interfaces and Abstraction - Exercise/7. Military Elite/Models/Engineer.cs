using _7._Military_Elite.Enumerationas;
using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(
            int id, 
            string firstName,
            string lastName,
            decimal salary,
            SoldierCorpEnum soldierCorpEnum,
            ICollection<IRepair> repairs) 
            : base(id, firstName, 
                  lastName, salary, soldierCorpEnum)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }
    }
}
