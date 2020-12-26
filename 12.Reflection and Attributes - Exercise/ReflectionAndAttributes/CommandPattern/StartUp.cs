using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpretator = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpretator);
            engine.Run();
        }
    }
}
