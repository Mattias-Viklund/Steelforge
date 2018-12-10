using System;
using SFML.Graphics;
using Steelforge.Rendering;
using Steelforge;
using SFML.Window;
using System.Collections.Generic;

namespace Steelforge.Game
{
    class Program
    {
        public static Engine engine;
        public static GameState gameState;

        static void Main(string[] args)
        {
            Console.Title = "Steelforge Debug";
            Console.WriteLine("Starting Steelforge");

            float number = 69.69f;
            Console.WriteLine("Number: "+number);
            Console.WriteLine("RSQRT: "+Q_rsqrt(number));

            engine = new Engine(new RenderWindow(new VideoMode(1280, 720), "Steelforge Debug"));
            gameState = new GameState(20);

            engine.PushState(gameState);
            engine.SetClearColor(Color.Black);
            engine.SetDebug(true); 

            engine.GetWindow().RequestFocus();
            engine.SetCustomCursor(new Texture(".\\Game\\Assets\\Cursor.png"));
            engine.SetMouseMode(Misc.MouseMode.CustomCursor);

            engine.Start();

            Console.WriteLine("Finished Execution.");

        }

        unsafe static float Q_rsqrt(float number)
        {
            long i;
            float x2, y;
            const float threehalfs = 1.5F;

            x2 = number * 0.5F;
            y = number;
            i = *(long*)&y;                       // evil floating point bit level hacking
            i = 0x5f3759df - (i >> 1);               // what the fuck? 
            y = *(float*)&i;
            y = y * (threehalfs - (x2 * y * y));   // 1st iteration
                                                   //	y  = y * ( threehalfs - ( x2 * y * y ) );   // 2nd iteration, this can be removed

            return y;

        }
    }
}
