using System.Linq;
using _03.Telephony.Exceptions;
using _03._Telephony.Models.Contacts;

namespace _03.Telephony
{
    public class StationaryPhone : ICalable
    {
        public StationaryPhone()
        {
        }

        public string Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new InvalidNumber();
            }

            return $"Dialing... {number}";
        }
    }


}