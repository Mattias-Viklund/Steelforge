using SFML.Window;
using Steelforge.Engine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Engine.Input
{
    public class InputManager
    {
        public static int PRESSED_KEYS = 0x0;
        public static int PRESSED_MOUSEBUTTONS = 0x0;

        public static int HELD_KEYS = 0x0;
        public static int HELD_MOUSEBUTTONS = 0x0;

        public static int PREV_PRESSED_KEYS = 0x0;
        public static int PREV_PRESSED_MOUSEBUTTONS = 0x0;

        public void MouseDown(MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case Mouse.Button.Left: PRESSED_MOUSEBUTTONS |= GlobalConstants.MOUSE_1; break;
                case Mouse.Button.Middle: PRESSED_MOUSEBUTTONS |= GlobalConstants.MOUSE_3; break;
                case Mouse.Button.Right: PRESSED_MOUSEBUTTONS |= GlobalConstants.MOUSE_2; break;

            }
        }

        public void KeyDown(KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.W: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.A: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.S: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.D: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;

                case Keyboard.Key.Space: PRESSED_KEYS |= GlobalConstants.KEYBOARD_SPACE; break;

                case Keyboard.Key.B: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.C: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.E: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.F: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.G: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.H: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.I: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.J: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.K: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.L: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.M: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.N: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.O: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.P: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.Q: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.R: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.T: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.U: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.V: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.X: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.Y: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;
                case Keyboard.Key.Z: PRESSED_KEYS |= GlobalConstants.KEYBOARD_W; break;

            }
        }

        public void NewFrame()
        {
            HELD_KEYS = PRESSED_KEYS & PREV_PRESSED_KEYS;
            HELD_MOUSEBUTTONS = PRESSED_MOUSEBUTTONS & PREV_PRESSED_MOUSEBUTTONS;

            PREV_PRESSED_KEYS = PRESSED_KEYS;
            PREV_PRESSED_MOUSEBUTTONS = PRESSED_MOUSEBUTTONS;

            PRESSED_KEYS = 0x0;
            PRESSED_MOUSEBUTTONS = 0x0;

        }
    }
}
