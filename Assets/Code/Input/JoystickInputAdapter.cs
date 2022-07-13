using UnityEngine;

namespace Input
{

    public class JoystickInputAdapter : Input
    {

        private readonly Joystick _joystick;
        private readonly JoyButton _joyButton;

        public JoystickInputAdapter(Joystick joystick, JoyButton joyButton)
        {
            _joystick = joystick;
            _joyButton = joyButton;
        }

        Vector2 Input.GetDirection()
        {
            return new Vector2(_joystick.Horizontal, _joystick.Vertical);
        }
        
        public bool IsFireActionPressed()
        {
            return _joyButton.IsPressed;
        }

    }
}