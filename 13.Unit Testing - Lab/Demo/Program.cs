using System;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person("Duygu");

            Console.WriteLine(person.WhatsMyName());
        }
    }
}
