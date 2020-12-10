using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyShouldLosesHealthIfAttacked()
    {
        //Arragne
        Dummy dummy = new Dummy(1000, 1000);

        //Act
        dummy.TakeAttack(10);

        //Assert
        var exceptedResult = 990;
        var actualresult = dummy.Health;

        Assert.AreEqual(exceptedResult, actualresult);
    }

    [Test]
    public void DaedDummyShouldReturnexception()
    {
        //Arragne
        Dummy dummy = new Dummy(0, 100);

        //Act - Assert

        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
    }

    [Test]
    public void DeadDummyShouldGiveiveXP()
    {
        //Arragne
        Dummy dummy = new Dummy(0, 100);

        //Act - Assert
        var exceptedResult = 100;
        var actualresult = dummy.GiveExperience();

        Assert.AreEqual(exceptedResult, actualresult);
    }
    [Test]
    public void AlivedDummyShouldNotGiveiveXP()
    {
        //Arragne
        Dummy dummy = new Dummy(10, 100);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}