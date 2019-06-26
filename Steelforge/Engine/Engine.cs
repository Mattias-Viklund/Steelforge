using System;

using SFML.Graphics;
using SFML.Window;
using SFML.System;
using Steelforge.Core;
using Steelforge.Rendering;
using Steelforge.Input;
using Steelforge.Misc;
using Steelforge.Core.States;

namespace Steelforge
{
    public class Engine
    {
        // Are we debugging?
        public static bool _debug = false;

        // Input manager
        public static InputManager inputManager = new InputManager();
        private static Command command = Command.None;

        private _EventHandler eventHandler = new _EventHandler();

        // Initialize the states
        private static StateBase currentState = StateBase._empty;
        private StateBase newState = currentState;

        // Ticks Per Second
        const uint TPS = 20;

        // Default engine font
        public static Font engineFont = new Font("lucon.ttf");

        // Window stuff
        private RenderWindow window;
        private DrawBuffer staticDrawBuffer = new DrawBuffer(0xFFFF);
        private RenderTexture texture;
        private DebugUtils debugUtils = new DebugUtils(engineFont);

        private MouseMode mouseMode = MouseMode.Default;
        private CustomCursor cursor = null;

        private Color clearColor = Color.Black;
        private Vector2f center;

        // Render Texture
        Sprite postLayer;

        public Engine(RenderWindow window)
        {
            this.window = window;
            this.texture = new RenderTexture(window.Size.X, window.Size.Y);
            this.texture.SetView(window.GetView());
            this.postLayer = new Sprite();
            this.postLayer.Position = new Vector2f(0, 0);
            this.postLayer.TextureRect = new IntRect(0, (int)window.Size.Y, (int)window.Size.X, -(int)window.Size.Y);
            this.center = new Vector2f(window.Size.X / 2, window.Size.Y / 2);
            Setup();

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
            Time deltaTime = Time.Zero; // Delta time of frame

            // Initialize the current state at least once
            currentState.Init(window);

            while (window.IsOpen && currentState != null)
            {
                // We shouldn't handle draw queue clearing, the StateBase should.
                // drawBuffer.Clear();

                if (currentState.GetID() != newState.GetID())
                    SwapState();

                time = timer.ElapsedTime;
                deltaTime = time - lastTime;

                lastTime = time;
                lag += deltaTime;

                CheckCommand();

                // Dispatch window events
                window.DispatchEvents();

                if (currentState.WantsExtendedUpdate())
                    currentState.ExtendedUpdate(deltaTime, this);

                // Update for set amount of time
                while (lag >= timePerUpdate)
                {
                    ticks++;
                    lag -= timePerUpdate;
                    Update(deltaTime);

                }

                // TODO: Add comment that makes sense
                FixedUpdate(deltaTime);
                CheckEvents(deltaTime);

                window.Clear(clearColor);
                texture.Clear();

                staticDrawBuffer = currentState.Render();

                // Draw our framebuffer
                staticDrawBuffer.Draw(texture);

                this.postLayer.Texture = texture.Texture;

                window.Draw(postLayer);

                LateUpdate(deltaTime);

                // Display the screen
                window.Display();

            }
        }

        private void CheckEvents(Time time)
        {


        }

        // Push a State
        public void PushState(StateBase state)
        {
            if (currentState.GetID() == StateBase._empty.GetID())
            {
                currentState = state;

            }
            this.newState = state;

        }

        public int AddStaticDrawable(StaticDrawable drawable)
        {
            return staticDrawBuffer.Add(drawable);

        }

        // Allows for a state to push a command, even if it doesn't have control over this
        public static void Push(Command command)
        {
            Engine.command = command;

        }

        public RenderWindow GetWindow()
        {
            return window;

        }

        // Methods For Setting
        #region Set
        public void SetMouseMode(MouseMode mouseMode)
        {
            this.mouseMode = mouseMode;

            // FPS MODE
            switch (mouseMode)
            {
                case MouseMode.Default:
                    window.SetMouseCursorVisible(true);
                    break;

                case MouseMode.FPS:
                    window.SetMouseCursorVisible(false);
                    break;

                case MouseMode.CustomCursor:
                    if (cursor == null)
                    {
                        mouseMode = MouseMode.Default;
                        break;

                    }
                    window.SetMouseCursorVisible(false);
                    break;

            }
        }

        public void SetCustomCursor(Texture texture)
        {
            cursor = new CustomCursor((Vector2f)texture.Size, texture);

        }

        public void SetDebug(bool debug)
        {
            _debug = debug;

        }

        public void SetClearColor(Color color)
        {
            this.clearColor = color;

        }

        public void SetIcon(string path)
        {
            Image img = new Image(path);
            window.SetIcon(img.Size.X, img.Size.Y, img.Pixels);

        }

        #endregion

        // Private Methods
        #region Private
        private void DrawDebugTools(Time time)
        {
            debugUtils.UpdateFPS(time);
            window.Draw(debugUtils);

        }

        private void FixedUpdate(Time time)
        {
            if (_debug)
                Debug.Flush();
            currentState.FixedUpdate(time);

        }

        private void LateUpdate(Time time)
        {
            if (_debug)
                DrawDebugTools(time);

            if (mouseMode == MouseMode.CustomCursor)
            {
                cursor.SetPosition(InputManager.MOUSE_POSITION);
                window.Draw(cursor);

            }

            currentState.LateUpdate(time);

        }

        private void Update(Time time)
        {
            if (mouseMode == MouseMode.FPS)
            {
                inputManager.IgnoreNextMouseInput();
                Mouse.SetPosition(window.Position + (Vector2i)center);
                InputManager.MOUSE_POSITION = center;

            }

            currentState.Update(time);

        }

        private void SwapState()
        {
            currentState = newState;
            currentState.Init(window);

        }

        private void CheckCommand()
        {
            if (command != Command.None)
            {
                switch (command)
                {
                    case Command.Close:
                        Close(null, null);
                        break;

                }
                command = Command.None;

            }
        }
        #endregion

        // Setup Events
        #region Setup
        void Setup()
        {
            window.Closed += new EventHandler(Close);
            window.KeyPressed += new EventHandler<KeyEventArgs>(KeyDown);
            window.KeyReleased += new EventHandler<KeyEventArgs>(KeyUp);
            window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(MouseDown);
            window.MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(MouseUp);
            window.MouseWheelMoved += new EventHandler<MouseWheelEventArgs>(MouseScrolled);
            window.SetKeyRepeatEnabled(false);
            window.MouseMoved += new EventHandler<MouseMoveEventArgs>(MouseMoved);

        }

        private void MouseScrolled(object sender, MouseWheelEventArgs e)
        {
            inputManager.MouseScrolled(sender, e);

        }

        private void MouseMoved(object sender, MouseMoveEventArgs e)
        {
            inputManager.MouseMoved(sender, e);

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
            window.Close();

        }
        #endregion

        #region FormEngine
        public void FormUpdate()
        {
            Time deltaTime = Time.Zero;

            if (currentState.GetID() != newState.GetID())
                SwapState();

            CheckCommand();

            // Dispatch window events
            window.DispatchEvents();

            if (currentState.WantsExtendedUpdate())
                currentState.ExtendedUpdate(deltaTime, this);

            Update(deltaTime);
            FixedUpdate(deltaTime);
            CheckEvents(deltaTime);

            staticDrawBuffer = currentState.Render();

            // Draw our framebuffer
            staticDrawBuffer.Draw(texture);

            this.postLayer.Texture = texture.Texture;

            window.Draw(postLayer);

            LateUpdate(deltaTime);

        }

        public void FormClear()
        {
            window.Clear(clearColor);
            texture.Clear();

        }

        public void FormDisplay()
        {
            // Display the screen
            window.Display();

        }

        public void FormInit()
        {
            currentState.Init(window);

        }
        #endregion
    }
}
