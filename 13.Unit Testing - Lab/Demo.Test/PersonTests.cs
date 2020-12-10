using NUnit.Framework;
using System;

namespace Demo.Test
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        
        public void DoesWhatsMyNameWorks()
        {
            Person person = new Person("Duygu");

            string expectedResult = "My name is Duygu";
            string actualResult = person.WhatsMyName();

            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}
