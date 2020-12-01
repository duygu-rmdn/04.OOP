using _03._Shopping_Spree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Shopping_Spree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> product;
        public Engine()
        {
            this.people = new List<Person>();
            this.product = new List<Product>();
        }
        public void Run()
        {
            try
            {
                this.ReadPerson();
                this.ReadProduct();
                string commmand;
                while ((commmand = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = commmand.Split();
                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];
                    Person person = this.people.FirstOrDefault(p => p.Name == personName);
                    Product product = this.product.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);
                        Console.WriteLine(result);
                    }

                }
                foreach (Person person in this.people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                throw;
            }
            
        }

        private void ReadPerson()
        {
            string[] peopleArg = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var personStr in peopleArg)
            {
                string[] personArg = personStr.Split("=");
                string personName = personArg[0];
                decimal personMoney = decimal.Parse(personArg[1]);
                Person person = new Person(personName, personMoney);
                this.people.Add(person);
            }
        }

        private void ReadProduct()
        {
            string[] productsArg = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var productStr in productsArg)
            {
                string[] productArg = productStr.Split("=");
                string productName = productArg[0];
                decimal productCost = decimal.Parse(productArg[1]);
                Product product = new Product(productName, productCost);
                this.product.Add(product);
            }
        }
    }
}
