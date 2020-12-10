using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100, 100, 10, 10, 9)]
    [TestCase(100, 100, 100, 100, 99)]
    [TestCase(235, 76, 132, 24, 23)]

    public void WeaponShoudLostDirabilityAfterAttack(int health, int experience, int attack, int dirability, int exceptresult)
    {
        //Arragne
        Dummy dummy = new Dummy(health, experience);
        Axe axe = new Axe(attack, dirability);
        //Act
        axe.Attack(dummy);
        //Assert
        var exeptResult = exceptresult;
        var actualresult = axe.DurabilityPoints;
        Assert.AreEqual(exeptResult, actualresult);
    }
    [Test]
    [TestCase(100, 100, 100, 0)]
    public void AttackShoulThrowInvalidOpetationExceptionWhenAxeDurabilityIsBeloweZero(int health, int experience, int attack, int dirability)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);
        Axe axe = new Axe(attack, dirability);
        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        //Assert

    }
}