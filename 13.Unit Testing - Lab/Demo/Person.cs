using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string WhatsMyName()
        {
            return $"My name is {this.Name}";
        }
    }
}
