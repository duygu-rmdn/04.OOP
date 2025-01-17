﻿namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {

        }

        public override int Fire()
        {
            if (BulletsCount > 0)
            {
                BulletsCount--;
                return 1;
            }

            return 0;
        }
    }
}