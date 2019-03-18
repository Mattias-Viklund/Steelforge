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
        // public static GameState gameState;
        public static GameState gameState;

        static void Main(string[] args)
        {
            Console.Title = "Steelforge Debug";
            Console.WriteLine("Starting Steelforge");

            engine = new Engine(new RenderWindow(new VideoMode(1280, 720), "Steelforge Debug"));
            gameState = new GameState(20);

            engine.PushState(gameState);
            engine.SetClearColor(Color.Black);
            engine.SetDebug(false);

            engine.GetWindow().RequestFocus();
            engine.SetCustomCursor(new Texture(".\\Game\\Assets\\Cursor.png"));
            engine.SetMouseMode(Misc.MouseMode.CustomCursor);

            engine.Start();

            Console.WriteLine("Finished Execution.");

        }
    }
}
