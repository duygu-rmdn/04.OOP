﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Interfaces
{
    public interface IEngineer
    {
        ICollection<IRepair> Repairs { get; }
    }
}
