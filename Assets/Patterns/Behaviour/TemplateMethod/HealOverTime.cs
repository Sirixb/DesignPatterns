using UnityEngine;

namespace Patterns.TemplateMethod
{
    [CreateAssetMenu(menuName = "TemplateMethod/Create HealOverTime", fileName = "HealOverTime", order = 0)]
    public class HealOverTime : ActiveSkill
    {
        [SerializeField] private float _secondsActive;
        [SerializeField] private int healthToAd;

        private float _currentTimeInSeconds;
        private bool _isActivate;
        private Hero _hero;

        protected override void DoUpdate()
        {
            if (!_isActivate)
            {
                return;
            }
            
            _hero.AddHealth(healthToAd * Time.deltaTime);
            
            _currentTimeInSeconds += Time.deltaTime;
            if (_currentTimeInSeconds > _secondsActive)
            {
                _isActivate = false;
            }
        }

        protected override void DoActivate(Hero hero)
        {
            _isActivate = true;
            _currentTimeInSeconds = 0;
            _hero = hero;
        }
    }
}
