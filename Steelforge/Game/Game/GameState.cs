using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Steelforge;
using Steelforge.Core;
using Steelforge.Input;
using Steelforge.Rendering;
using Steelforge.TileSystem;
using Steelforge.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steelforge.Core.States;
using Steelforge.Objects;

namespace Steelforge.Game
{
    class GameState : StateBase
    {
        private DrawBuffer queue;

        // Keep track of the screen
        private Vector2u size;
        private Vector2u center;

        private Square[] squares = new Square[3];
        private Text selectedSquareText = new Text("Selected Square: 0", Engine.engineFont, 14) { Position = new Vector2f(50, 50) };
        private int selectedSquare = 0;
        private Vector2f squareVelocity = new Vector2f(200, 0);

        private GameDrawable text1;

        public GameState(int drawLimit)
        {
            queue = new DrawBuffer(drawLimit);

            FillSquares();

        }

        private void FillSquares()
        {
            squares[0] = new Square(new Vector2f(200, 200), new Vector2f(500, 500), Color.Yellow);
            squares[1] = new Square(new Vector2f(200, 200), new Vector2f(800, 500), Color.Blue);
            squares[2] = new Square(new Vector2f(200, 200), new Vector2f(1000, 500), Color.White);

        }

        public override void Init(RenderWindow window)
        {
            this.size = window.Size;
            this.center = new Vector2u(size.X / 2, size.Y / 2);

            base.RequestExtendedUpdate();

        }

        public override void Update(Time time)
        {
            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_ESCAPE))
            {
                base.Close();

            }

            for (int i = 0; i< squares.Length; i++)
            {
                squares[i].Update(time);

            }
        }

        private void SelectSquare(bool next)
        {
            if (next)
            {
                selectedSquare++;
                if (selectedSquare == squares.Length)
                    selectedSquare = 0;

            }
            else
            {
                selectedSquare--;
                if (selectedSquare < 0)
                    selectedSquare = squares.Length - 1;

            }

            selectedSquareText.DisplayedString = "Selected Square: " + selectedSquare;

        }

        private void MoveSquare(bool left, Time time)
        {
            if (left)
                squares[selectedSquare].SetVelocity(new Vector2f(-500, -300));
            else
                squares[selectedSquare].SetVelocity(new Vector2f(500, 100));

        }

        public override void FixedUpdate(Time time)
        {
            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_UP))
                SelectSquare(true);

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_DOWN))
                SelectSquare(false);

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_LEFT))
                MoveSquare(true, time);

            if (InputManager.KeyPressed(GlobalConstants.KEYBOARD_RIGHT))
                MoveSquare(false, time);

            queue.Clear();

            for (int i = 0; i < squares.Length; i++)
                squares[i].collided = false;

            Square.Collide(ref squares);

            foreach (Square square in squares)
                queue.Add(square);

            text1 = new GameRenderable(selectedSquareText);
            queue.Add(text1);

            foreach (GameObject gObj in GameObject.gameObjects)
            {
                queue.Add(gObj);
 
            }
        }

        protected override void Update(Time time, Engine engine)
        {

        }

        public override DrawBuffer Render()
        {
            return queue;

        }
    }
}
