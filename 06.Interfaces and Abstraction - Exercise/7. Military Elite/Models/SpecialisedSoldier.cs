using _7._Military_Elite.Enumerationas;
using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id,
            string firstName,
            string lastName, 
            decimal salary,
            SoldierCorpEnum soldierCorpEnum)
            : base(id, firstName, 
                  lastName, salary)
        {
             this.SoldierCorpEnum = soldierCorpEnum;
        }

        public SoldierCorpEnum SoldierCorpEnum { get; }
    }
}
