using _03._Telephony.Core.Contacts;
using _03._Telephony.Models;
using _03.Telephony;
using _03.Telephony.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Telephony.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;

        private Smartphone smartPhone;
        private StationaryPhone stationaryPhone;

        public Engine()
        {
            smartPhone = new Smartphone();
            stationaryPhone = new StationaryPhone();
        }

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] numbers = reader.ReadLine().Split(' ');
            string[] sides = reader.ReadLine().Split(' ');

            CallTheNumber(numbers);
            Browsing(sides);

        }
        public void CallTheNumber(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        writer.WriteLine(smartPhone.Call(number));
                    }
                    else
                    {
                        //Console.WriteLine(stationaryPhone.Call(number));
                        writer.WriteLine(stationaryPhone.Call(number));
                    }
                }
                catch (InvalidNumber ui)
                {
                    writer.WriteLine(ui.Message);
                }
            }
        }
        public void Browsing(string[] sides)
        {
            foreach (var side in sides)
            {
                try
                {
                    writer.WriteLine(smartPhone.Browse(side));
                }
                catch (InvalidUrl ui)
                {
                    writer.WriteLine(ui.Message);
                }
            }
        }

    }
}
