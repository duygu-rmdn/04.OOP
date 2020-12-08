using Logger.Models.Enumerations;
using System;

namespace Logger.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }
        string Messege { get; }
        Level level { get; }
    }
}