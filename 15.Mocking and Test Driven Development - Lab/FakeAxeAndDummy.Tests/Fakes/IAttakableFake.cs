using FakeAxeAndDummy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Tests.Fakes
{
    public class IAttakableFake : IAttakable
    {
        public int Health => throw new NotImplementedException();

        public int GiveExperience()
        =>20;

        public bool IsDead() => true;

        public void TakeAttack(int attackPoints)
        {
        }
    }
}
