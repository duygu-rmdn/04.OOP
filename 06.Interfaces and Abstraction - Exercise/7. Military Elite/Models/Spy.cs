﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }
    }
}
