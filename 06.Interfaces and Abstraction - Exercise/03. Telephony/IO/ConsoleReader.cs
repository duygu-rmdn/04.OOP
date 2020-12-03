using _03._Telephony.Core.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Telephony.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

       
    }
}
