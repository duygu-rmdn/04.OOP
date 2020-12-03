using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }
        public string PartName { get; }

        public int HoursWorked { get; }
    }
}
