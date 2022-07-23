using Patterns.Builder.Armors;
using Patterns.Builder.Weapons;
using UnityEngine;

namespace Patterns.Builder
{
    public class HeroBuilder
    {
        private Hero _prefab;
        private Armor _armor;
        private Weapon _weapon;

        public HeroBuilder WithArmor(Armor armor)
        {
            _armor = armor;
            return this;
        }

        public HeroBuilder WithWeapon(Weapon weapon)
        {
            _weapon = weapon;
            return this;
        }

        public HeroBuilder FromHeroPrefab(Hero prefab)
        {
            _prefab = prefab;
            return this;
        }

        public Hero Build()
        {
            var hero = Object.Instantiate(_prefab);
            var weapon = Object.Instantiate(_weapon, hero.transform);
            var armor = Object.Instantiate(_armor, hero.transform);
            hero.SetComponents(weapon, armor);

            return hero;
        }
    }
}
