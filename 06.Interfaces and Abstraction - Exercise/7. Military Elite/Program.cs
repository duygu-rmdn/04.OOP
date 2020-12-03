using _7._Military_Elite.Interfaces;
using _7._Military_Elite.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace _7._Military_Elite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICollection<ISoldier> soldiers = new List<ISoldier>();
            string command;
            ISoldier soldier;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commantTolkens = command.Split();
                string soldierType = commantTolkens[0];

                if (soldierType == typeof(Private).Name)
                {
                    soldier = new Private(1,"","",1.3m);
                }
                else if (soldierType == typeof(Spy).Name)
                {

                }
            }

            PrintResult(soldiers);
        }

        private static void PrintResult(ICollection<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
