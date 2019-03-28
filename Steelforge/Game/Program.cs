﻿using System;
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
        public static Minesweeper gameState;

        static void Main(string[] args)
        {
            Console.Title = "Steelforge Debug";
            Console.WriteLine("Starting Steelforge");

            engine = new Engine(new RenderWindow(new VideoMode(400, 400), "Steelforge Debug"));
            gameState = new Minesweeper();

            engine.PushState(gameState);
            engine.SetClearColor(new Color(220, 220, 220));

            engine.SetDebug(false);

            engine.GetWindow().RequestFocus();
            engine.Start();

            Console.WriteLine("Finished Execution.");

        }
    }
}
