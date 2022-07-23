using System;
using UnityEngine;
using Input;
using Ships.CheckLimits;
using Ships.Enemies;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useAI;
        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JoyButton _joyButton;
        [SerializeField] private ShipMediator _ship;

        [SerializeField] private ShipToSpawnConfiguration _shipToSpawnConfiguration;

        private void Awake()
        {

                _ship.Configure(GetInput(), GetCheckLimitsStrategy(),
                                _shipToSpawnConfiguration.Speed,
                                _shipToSpawnConfiguration.FireRate,
                                _shipToSpawnConfiguration.DefaultProjectileId);
  
        }

        private CheckLimits.CheckLimits GetCheckLimitsStrategy()
        {
            if (_useAI)
            {
                return new InitialPositionCheckLimits(_ship.transform, 10f);
            }

                return new ViewportCheckLimits(_ship.transform,Camera.main);
        }

        private Input.Input GetInput()
        {
            if (_useAI)
            {
                return new AIInputAdapter(_ship);
            }
            if (_useJoystick)
            {
                return new JoystickInputAdapter(_joystick, _joyButton);
            }

            Destroy(_joystick.gameObject);
            Destroy(_joyButton.gameObject);
            return new UnityInputAdapter();
        }
    }
}
