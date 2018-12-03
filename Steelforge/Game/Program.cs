using System;
using SFML.Graphics;
using Steelforge.Engine.Rendering;
using Steelforge.Engine;
using SFML.Window;

namespace Steelforge.Game
{
    class Program
    {
        public static Main engine;
        public static GameState gameState;

        static void Main(string[] args)
        {
            Console.Title = "";
            Console.WriteLine("Starting Steelforge");

            engine = new Main(new RenderWindow(new VideoMode(1280, 720), "Engine"));
            gameState = new GameState(256);

            engine.PushState(gameState);
            engine.SetClearColor(new Color(30, 30, 30));
            engine.Debug(true);

            engine.Start();

            Console.WriteLine("Finished Executing.");

        }
    }
}
