﻿using System;
using System.Text;

using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                username = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                health = value;
            }
        }

        public int Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                armor = value;
            }
        }

        public IGun Gun
        {
            get => gun;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                gun = value;
            }
        }

        public bool IsAlive
            => Health > 0 ? true : false; //Health >= 0 ?;

        public void TakeDamage(int points)
        {
            if (Armor > 0)
            {
                if (Armor - points >= 0)
                {
                    Armor -= points;
                }
                else
                {
                    int pointBelowTheArmor = Math.Abs(Armor - points);

                    Armor = 0;
                    Health -= pointBelowTheArmor;
                }
            }
            else
            {
                if (Health - points < 0)
                {
                    Health = 0;
                }

                Health -= points;
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{this.GetType().Name}: {Username}")
                .AppendLine($"--Health: {Health}")
                .AppendLine($"--Armor: {Armor}")
                .AppendLine($"--Gun: {Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}