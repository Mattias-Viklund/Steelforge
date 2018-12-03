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

        unsafe static void Main(string[] args)
        {
            Console.Title = "";
            Console.WriteLine("Starting Steelforge");

            //engine = new Engine(new RenderWindow(new VideoMode(1280, 720), "Engine"));
            //gameState = new GameState(256);

            //engine.PushState(gameState);
            //engine.SetClearColor(Color.Black);
            //engine.Debug(false);

            //engine.Start();

            Console.WriteLine("Finished Execution.");
            Console.ReadLine();

        }
    }
}
