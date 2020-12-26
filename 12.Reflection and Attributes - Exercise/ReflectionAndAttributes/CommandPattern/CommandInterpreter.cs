using CommandPattern.Core.Comands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inpuTrokens = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string comandType = inpuTrokens[0].ToLower();
            string[] comandArgunemts = inpuTrokens
                .Skip(1)
                .ToArray();

            //ICommand command = default;
            // with reflection:

            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == $"{comandType}Command".ToLower());
            ICommand instance = (ICommand)Activator.CreateInstance(type);

            // without reflection:
            //if (comandType == "Hello")
            //{
            //    command = new HelloCommand();
            //}
            //else if (comandType == "Exit")
            //{
            //    command = new ExitCommand();
            //}
            //string result = command.Execute(comandArgunemts);
            string result = instance.Execute(comandArgunemts);

            return result;
        }
    }
}
