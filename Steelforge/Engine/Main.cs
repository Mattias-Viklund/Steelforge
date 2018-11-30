using System;

using SFML.Graphics;
using SFML.Window;
using SFML.System;
using Steelforge.Engine.Core;
using Steelforge.Engine.Rendering;
using Steelforge.Engine.Input;

namespace Steelforge.Engine
{
    public class Main
    {
        // Are we debugging?
        public static bool _debug = false;

        private Color clearColor = Color.Black;

        // Ticks Per Second
        const uint TPS = 20;

        // Initialize the states
        private static StateBase currentState = StateBase._empty;
        private StateBase newState = currentState;

        private Screen screen;
        public static InputManager inputManager = new InputManager();
        private DrawQueue drawQueue = new DrawQueue(9999);

        public Main(Screen screen)
        {
            this.screen = screen;
            Setup();

        }

        public void SetClearColor(Color color)
        {
            this.clearColor = color;

        }

        public void SetIcon(string path)
        {
            Image img = new Image(path);
            screen.GetWindow().SetIcon(img.Size.X, img.Size.Y, img.Pixels);

        }

        public void Start()
        {
            Time timePerUpdate = Time.FromSeconds(1.0f / (float)TPS);
            uint ticks = 0;

            Clock timer = new Clock();

            // Timing variables
            Time lastTime = Time.Zero; // Set to time of last frame
            Time lag = Time.Zero; // For FixedUpdate()
            Time time = Time.Zero; // Time of current frame
            Time deltaTime = Time.Zero; // Deta time of frame

            // Initialize the current state at least once
            currentState.Init(screen);

            while (screen.GetWindow().IsOpen && currentState != null)
            {
                if (currentState.GetID() != newState.GetID())
                    SwapState();

                time = timer.ElapsedTime;
                deltaTime = time - lastTime;

                lastTime = time;
                lag += deltaTime;

                // Dispatch window events
                screen.GetWindow().DispatchEvents();
                currentState.Update(deltaTime);

                if (currentState.WantsExtendedUpdate())
                    currentState.ExtendedUpdate(deltaTime, screen);

                //Fixed time update
                while (lag >= timePerUpdate)
                {
                    ticks++;
                    lag -= timePerUpdate;
                    currentState.FixedUpdate(deltaTime);

                }

                // Hand over control of the drawQueue to the current state.
                currentState.Render(ref drawQueue);

                // Clear the window and prepare for next draw;
                screen.GetWindow().Clear(clearColor);

                // Draw our framebuffer
                screen.GetWindow().Draw(drawQueue);

                // Display the screen
                screen.GetWindow().Display();

            }
        }

        public Screen GetScreen()
        {
            return this.screen;

        }

        public void PushState(StateBase state)
        {
            if (currentState.GetID() == StateBase._empty.GetID())
            {
                currentState = state;

            }
            this.newState = state;

        }

        private void SwapState()
        {
            currentState = newState;
            currentState.Init(screen);

        }

        #region Setup
        void Setup()
        {
            screen.GetWindow().Closed += new EventHandler(Close);
            screen.GetWindow().KeyPressed += new EventHandler<KeyEventArgs>(KeyDown);
            screen.GetWindow().KeyReleased += new EventHandler<KeyEventArgs>(KeyUp);
            screen.GetWindow().MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(MouseDown);
            screen.GetWindow().MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(MouseUp);
            screen.GetWindow().MouseMoved += new EventHandler<MouseMoveEventArgs>(MouseMoved);
            screen.GetWindow().MouseWheelMoved += new EventHandler<MouseWheelEventArgs>(MouseScrolled);
            screen.GetWindow().SetKeyRepeatEnabled(false);


        }

        private void MouseScrolled(object sender, MouseWheelEventArgs e)
        {
            currentState.MouseScrolled(sender, e);

        }

        private void MouseMoved(object sender, MouseMoveEventArgs e)
        {
            currentState.MouseMoved(sender, e);

        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            inputManager.MouseDown(e);
        }

        private void MouseUp(object sender, MouseButtonEventArgs e)
        {
            inputManager.MouseUp(e);
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            inputManager.KeyDown(e);
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            inputManager.KeyUp(e);
        }

        public void Close(object sender, EventArgs e)
        {
            screen.GetWindow().Close();

        }
        #endregion

    }
}
