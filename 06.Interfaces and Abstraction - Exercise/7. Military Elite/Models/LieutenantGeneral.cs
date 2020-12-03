using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, List<IPrivate> privates) : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public ICollection<IPrivate> Privates { get; }
    }
}
