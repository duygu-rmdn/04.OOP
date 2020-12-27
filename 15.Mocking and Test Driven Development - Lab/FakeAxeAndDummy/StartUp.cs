using FakeAxeAndDummy.Contracts;
using Moq;
using System;

public class StartUp
{
    static void Main(string[] args)
    {
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        weapon.Setup(w=>w.AttackPoints).Returns(12);
        Console.WriteLine(weapon.Object.AttackPoints);

        Hero hero = new Hero("Name", weapon.Object);

    }
}
