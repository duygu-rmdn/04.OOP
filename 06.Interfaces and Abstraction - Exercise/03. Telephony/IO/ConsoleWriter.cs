using _03._Telephony.Core.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Telephony.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
             Console.Write(text);
        }

        public void WriteLine(string text)
        {
             Console.WriteLine(text);
        }
    }
}
