using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Telephony.Core.Contacts
{
    public interface IWriter
    {
        public void WriteLine(string text);
        public void Write(string text);

    }
}
