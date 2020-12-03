using _03._Telephony.Models.Contacts;
using _03.Telephony.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Telephony.Models
{
    public class Smartphone : ICalable, IBrowseble
    {

        public Smartphone()
        {

        }
        public string Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new InvalidNumber();
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {

            if (url.Any(x => char.IsNumber(x)))
            {
                throw new InvalidUrl();
            }

            return $"Browsing: {url}!";
        }


    }
}