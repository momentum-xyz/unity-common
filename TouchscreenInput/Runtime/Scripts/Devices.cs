using UnityEngine;

namespace Momentum.UnityCommon.TouchscreenInput
{
    /// <summary>
    /// A static class that holds inputs of the joystick and the touchpad.
    /// Only one of each virtual devices is supported.
    /// </summary>
    public static class Devices
    {
        public static Vector2 joystick = Vector2.zero;
        public static Vector2 touchpad = Vector2.zero;
    }
}