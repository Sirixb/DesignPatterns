using System;

namespace Patterns.Facade
{
    [Serializable]
    public abstract class Hero
    {
        public int Health;

        public Hero(int health)
        {
            Health = health;
        }
    }
}
