using System;
using Input;
using Ships.CheckLimits;
using Ships.Enemies;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace Ships.Common
{
    public class ShipBuilder
    {
        public enum InputMode
        {
            Unity,
            Joystick,
            Ai
        }

        public enum CheckLimitTypes
        {
            InitialPosition,
            Viewport
        }

        private ShipMediator _prefab;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private Input.Input _input;
        private CheckLimits.CheckLimits _checkLimits;
        private ShipToSpawnConfiguration _shipConfiguration;
        private InputMode _inputMode;
        private Joystick _joystick;
        private JoyButton _joyButton;
        private CheckLimitTypes _checkLimitType;

        public ShipBuilder FromPrefab(ShipMediator prefab)
        {
            _prefab = prefab;
            return this;
        }

        public ShipBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public ShipBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }

        public ShipBuilder WithInput(Input.Input input)
        {
            _input = input;
            return this;
        }

        public ShipBuilder WithCheckLimits(CheckLimits.CheckLimits checkLimits)
        {
            _checkLimits = checkLimits;
            return this;
        }

        public ShipBuilder WithConfiguration(ShipToSpawnConfiguration shipConfiguration)
        {
            _shipConfiguration = shipConfiguration;
            return this;
        }

        public ShipBuilder WithInputMode(InputMode inputMode)
        {
            _inputMode = inputMode;
            return this;
        }

        public ShipBuilder WithJoysticks(Joystick joystick, JoyButton joyButton)
        {
            _joystick = joystick;
            _joyButton = joyButton;
            return this;
        }

        public ShipBuilder WithCheckLimitType(CheckLimitTypes type)
        {
            _checkLimitType = type;
            return this;
        }


        private CheckLimits.CheckLimits GetCheckLimits(ShipMediator ship)
        {
            if (_checkLimits != null)
            {
                return _checkLimits;
            }

            switch (_checkLimitType)
            {
                case CheckLimitTypes.InitialPosition:
                    return new InitialPositionCheckLimits(ship.transform, 10);
                case CheckLimitTypes.Viewport:
                    return new ViewportCheckLimits(ship.transform, Camera.main);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Input.Input GetInput(ShipMediator shipMediator)
        {
            if (_input != null)
            {
                return _input;
            }

            switch (_inputMode)
            {
                case InputMode.Unity:
                    return new UnityInputAdapter();
                case InputMode.Joystick:
                    Assert.IsNotNull(_joystick);
                    Assert.IsNotNull(_joyButton);
                    return new JoystickInputAdapter(_joystick, _joyButton);
                case InputMode.Ai:
                    return new AIInputAdapter(shipMediator);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ShipMediator Build()
        {
            var ship = Object.Instantiate(_prefab, _position, _rotation);
            var shipConfiguration = new ShipConfiguration(GetInput(ship),
                                                          GetCheckLimits(ship),
                                                          _shipConfiguration.Speed,
                                                          _shipConfiguration.FireRate,
                                                          _shipConfiguration.DefaultProjectileId);
            ship.Configure(shipConfiguration);
            return ship;
        }
    }
}
