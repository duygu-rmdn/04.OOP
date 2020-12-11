using System.Linq;
using System;

using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StoringArraysCapacityMustBeExactly16Integers()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(numbers);

            //Act
            int expectedResult = 16;
            int actualResult = database.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void AddOperationShouldAddAnElementAtTheNextFreeCell()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(numbers);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(5));
        }
        [Test]
        public void RemoveOperationShouldSupportOnlyRemovingAnElementAtTheLast()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(numbers);

            //Act
            database.Remove();
            int expectedresult = 15;
            int actualResult = database.Count;
            //Assert
            Assert.AreEqual(expectedresult, actualResult);
        }
        [Test]
        public void AddOperationShouldThrowInvalidOperationExceptionIfTryToRemoveElementFromEmptyDatabaset()
        {
            // Arrange
            Database database = new Database();

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FretchOperationShouldReturnElementAsArray()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 5).ToArray();
            Database database = new Database(numbers);
            //Act
            int[] actualResult = database.Fetch();
            int[] exptedReult = { 1, 2, 3, 4, 5 };
            //Assret
            Assert.AreEqual(actualResult, exptedReult);
        }
    }
}