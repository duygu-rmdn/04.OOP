using FakeAxeAndDummy.Contracts;
using FakeAxeAndDummy.Tests.Fakes;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void GivenHero_ShouldReciseExpirience_WhenAttakedTargetDies()
    {
        IAttakable dummy = new IAttakableFake();
        IWeapon weapon = new IWeaponFake();
        Hero hero = new Hero("Name", weapon);
        hero.Attack(dummy);

        Assert.AreEqual(20, hero.Experience);
    }
}