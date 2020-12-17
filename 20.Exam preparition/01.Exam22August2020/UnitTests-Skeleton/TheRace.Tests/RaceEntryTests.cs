using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
            //UnitCar car = new UnitCar("model", 3000, 250);
            //UnitDriver driver = new UnitDriver(null, car);
        }

        [Test]
        public void NullName()
        {
            UnitCar car = new UnitCar("model", 3000, 250);
            //UnitDriver driver = new UnitDriver(null, car);

            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, car));
        }
        [Test]
        public void IsCtorWorks()
        {
            RaceEntry race = new RaceEntry();

            int actualResult = race.Counter;
            Assert.AreEqual(actualResult, 0);
        }

        [Test]
        public void AddNullDr()
        {
            RaceEntry race = new RaceEntry();
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void AddExistDr()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("model", 3000, 250);
            UnitDriver driver = new UnitDriver("name", car);

            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void LessThan0Start()
        {
            RaceEntry race = new RaceEntry();
            //UnitCar car = new UnitCar("model", 3000, 250);
            //UnitDriver driver = new UnitDriver("name", car);

            //race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAvg()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("model", 300, 250);
            UnitCar car1 = new UnitCar("model1", 100, 250);
            UnitDriver driver = new UnitDriver("name", car);
            UnitDriver driver1 = new UnitDriver("name1", car1);

            race.AddDriver(driver);
            race.AddDriver(driver1);

            double actualResult = race.CalculateAverageHorsePower();


            Assert.AreEqual(actualResult, 200);
        }
    }
}