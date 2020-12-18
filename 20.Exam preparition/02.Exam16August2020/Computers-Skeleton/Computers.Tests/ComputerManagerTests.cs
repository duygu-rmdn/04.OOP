using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Computer computer = new Computer("name", "model", 1.23m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        public void Test6()
        {
            Computer computer = null;
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        public void Test2()
        {
            Computer computer = new Computer("name", "model", 1.23m);
            ComputerManager computerManager = new ComputerManager();


            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "model"));
        }
        [Test]
        public void Test3()
        {
            Computer computer = new Computer("name", "model", 1.23m);
            ComputerManager computerManager = new ComputerManager();


            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("njksa", null));
        }

        [Test]
        public void Test4()
        {
            ComputerManager computerManager = new ComputerManager();


            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("njksa", null));
        }

        [Test]
        public void Test7()
        {
            Computer computer = new Computer("dasd", "asd", 12.3m);
            ComputerManager computerManager = new ComputerManager();


            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("njksa", null));
        }

        [Test]
        public void Test5()
        {
            Computer computer = new Computer("name", "model", 1.23m);
            ComputerManager computerManager = new ComputerManager();


            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));
        }
        [Test]
        public void Test8()
        {
            ComputerManager computerManager = new ComputerManager();
            Assert.AreEqual(computerManager.Count, 0);
        }

        [Test]
        public void Test9()
        {
            Computer computer = new Computer("asd", "asd", 12.3m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            Assert.AreEqual(computerManager.Count, 1);
        }

        [Test]
        public void Test10()
        {
            Computer computer = new Computer("asd", "asd", 12.3m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            computerManager.RemoveComputer("asd", "asd");
            Assert.AreEqual(computerManager.Count, 0);
        }


        [Test]
        public void Test11()
        {
            Computer computer = new Computer("asd", "asd", 12.3m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            computerManager.RemoveComputer("asd", "asd");
            Assert.AreEqual(computerManager.Count, 0);
        }


        [Test]
        public void Test12()
        {
            Computer computer = new Computer("name", "model", 1.23m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            List<Computer> list = new List<Computer>();
            list.Add(computer);
            Assert.AreEqual(list, computerManager.Computers);

        }
        [Test]
        public void Test13()
        {
            Computer computer = new Computer("name", "model", 1.23m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);


            Assert.AreEqual(computer, computerManager.Computers.First(x => x.Manufacturer == "name" && x.Model == "model"));
        }

        [Test]
        public void Test14()
        {
            Computer computer = new Computer("name", "model", 1.23m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);


            Assert.AreEqual(computer, computerManager.RemoveComputer("name", "model"));
        }

        [Test]
        public void Test15()
        {
            Computer computer = new Computer("name", "model", 1.23m);
            Computer computer1 = new Computer("name1", "model1", 1.231m);
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer1);
            computerManager.RemoveComputer("name", "model");

            Assert.AreEqual(1, computerManager.Computers.Count);

        }
        [Test]
        public void Test16()
        {
            Computer computer = new Computer("name", "model", 1.23m);
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("njksa", "model"));
        }

        [Test]
        public void Test17()
        {
            Computer computer = new Computer("name", "model", 1.23m);
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("name", "nakjda"));
        }
        [Test]
        public void IsGetComputerMethodReturnsCorrectComp()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);


            Assert.AreEqual(comp, manager.GetComputer("Apple", "MacBook"));
        }

        [Test]
        public void IsComputerPropReturn()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            Computer comp1 = new Computer("Apple", "MacBook1", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);
            manager.AddComputer(comp1);

            List<Computer> expectedResult = new List<Computer>();
            expectedResult.Add(comp);
            expectedResult.Add(comp1);

            var actualResult = manager.Computers;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void IsComputerConstructor()
        {
            Computer comp = new Computer("Apple", "MacBook", 1500.50M);

            Assert.AreEqual("Apple", comp.Manufacturer);
            Assert.AreEqual("MacBook", comp.Model);
            Assert.AreEqual(1500.50M, comp.Price);
        }

        [Test]
        public void IsComputerManagerConstructor()
        {
            ComputerManager manager = new ComputerManager();
            List<Computer> expectedResult = new List<Computer>();
            Assert.AreEqual(0, manager.Count);
            Assert.AreEqual(expectedResult, manager.Computers);
            Assert.AreEqual(0, manager.Computers.Count);

        }

        [Test]
        public void IsAddedCompIsNull_Should()
        {
            Computer comp = null;
            ComputerManager manager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(comp));
        }

        [Test]
        public void IsAddedCompIsExist_Should()
        {
            Computer comp = new Computer("Apple", "MacBook", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            Assert.Throws<ArgumentException>(() => manager.AddComputer(comp));
        }

        [Test]
        public void AddComputerMethod_Should()
        {
            Computer comp = new Computer("Apple", "MacBook", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            Assert.AreEqual(comp, manager.Computers.First(x => x.Manufacturer == "Apple" && x.Model == "MacBook"));
        }

        [Test]
        public void IsAddComputerChangeCount()
        {
            Computer comp = new Computer("Apple", "MacBook", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void IsRemoveComputerReturnCorrectComp()
        {
            Computer comp = new Computer("Apple", "MacBook", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            Assert.AreEqual(comp, manager.RemoveComputer("Apple", "MacBook"));
        }

        [Test]
        public void IsRemoveComputerChangeCount()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            Computer comp1 = new Computer("Apple1", "MacBook1", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);
            manager.AddComputer(comp1);
            manager.RemoveComputer("Apple", "MacBook");

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void GetComputerManufacturerCanNotBeNull()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);


            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, "MacBook"));
        }

        [Test]
        public void GetComputerModelCanNotBeNull()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);


            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("Apple", null));
        }

        [Test]
        public void IsInGetComputerItemWeLookedForDoesNotExist()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            Assert.Throws<ArgumentException>(() => manager.GetComputer("Apple12", "MacBook15"));
        }

       

        [Test]
        public void GetComputersByManufacturerCanNotBeNull()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);

            string man = null;

            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(man));
        }

        [Test]
        public void IsGetComputersByManufacturerReturnsCorrectComp()
        {
            Computer comp = new Computer("Apple", "MacBook", 1550.50M);
            Computer comp1 = new Computer("Apple", "MacBook1", 1500.50M);

            ComputerManager manager = new ComputerManager();
            manager.AddComputer(comp);
            manager.AddComputer(comp1);

            List<Computer> expectedResult = new List<Computer>();
            expectedResult.Add(comp);
            expectedResult.Add(comp1);


            Assert.AreEqual(expectedResult, manager.GetComputersByManufacturer("Apple"));
        }

       
    }
}