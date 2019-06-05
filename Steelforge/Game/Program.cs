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
        //public static Minesweeper gameState;
        public static GameState gameState;

        static void Main(string[] args)
        {
            Console.Title = "Steelforge Debug";
            Console.WriteLine("Starting Steelforge");

            engine = new Engine(new RenderWindow(new VideoMode(1920, 1080), "Steelforge Debug", Styles.Close));
            gameState = new GameState(0xFF);

            engine.PushState(gameState);
            engine.SetClearColor(new Color(220, 220, 220));

            engine.SetDebug(false);
            engine.SetMouseMode(Misc.MouseMode.FPS);

            engine.GetWindow().RequestFocus();
            engine.Start();

            Console.WriteLine("Finished Execution.");

        }
    }
}
