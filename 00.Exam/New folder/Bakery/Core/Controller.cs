using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> foods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        public Controller()
        {
            foods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink bakedFood = null;
            if (type == "Tea")
            {
                bakedFood = new Tea(name, portion, brand );
            }
            else if (type == "Water")
            {
                bakedFood = new Water(name, portion, brand);
            }
            drinks.Add(bakedFood);
            return $"Added {name} ({brand}) to the drink menu";

        }

        public string AddFood(string type, string name, decimal price)
        {
            BakedFood bakedFood = null;
            if (type == "Bread")
            {
                bakedFood = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                bakedFood = new Cake(name, price);
            }
            foods.Add(bakedFood);
            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Table table in tables)
            {
                if (table.IsReserved == false )
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            decimal income = 0.0m;
            foreach (Table table in tables)
            {
                if (table.IsReserved == true)
                {
                    income += table.GetBill();
                }
            }
            
            return $"Total income: {income:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            Table cuurTable = (Table)tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            decimal bill = cuurTable.GetBill();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: { tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            Table cuurTable = (Table)tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            Drink currFood = (Drink)drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (cuurTable == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (currFood == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            cuurTable.OrderDrink(currFood);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            Table cuurTable = (Table)tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            BakedFood currFood = (BakedFood)foods.FirstOrDefault(x => x.Name == foodName);

            if (cuurTable == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (currFood == null)
            {
                return $"No {foodName} in the menu";
            }
            cuurTable.OrderFood(currFood);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            foreach (Table table in tables)
            {
                if (table.IsReserved == false  && table.Capacity >= numberOfPeople)
                {
                    return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
                }
            }
            return $"No available table for {numberOfPeople} people";
        }
    }
}
