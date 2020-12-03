using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite.Interfaces
{
    public interface ILieutenantGeneral
    {
        ICollection<IPrivate> Privates { get; }
    }
}
