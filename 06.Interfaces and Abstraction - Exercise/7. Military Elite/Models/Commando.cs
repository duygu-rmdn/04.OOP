using _7._Military_Elite.Enumerationas;
using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Models
{
    public class Commando : SpecialisedSoldier, ICommando 
    {
        public Commando(
            int id, 
            string firstName,
            string lastName,
            decimal salary, 
            SoldierCorpEnum soldierCorpEnum, ICollection<IMitions> misions) : base(id, firstName, lastName, salary, soldierCorpEnum)
        {
            this.Misions = misions;
        }

        public ICollection<IMitions> Misions { get; }
    }
}
