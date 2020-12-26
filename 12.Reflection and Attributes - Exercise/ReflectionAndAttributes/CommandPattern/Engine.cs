using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter _commandInterpretator;
        public Engine(ICommandInterpreter commandInterpretator)
        {
            _commandInterpretator = commandInterpretator;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string result = _commandInterpretator.Read(input);
                Console.WriteLine(result);
            }
        }
    }
}
