using _03._Telephony.Core;
using _03._Telephony.Core.Contacts;
using _03._Telephony.IO;
using System;

namespace _03._Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
