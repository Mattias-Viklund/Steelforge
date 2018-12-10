using SFML.System;
using SFML.Window;

using SFML.Graphics;
using Steelforge.Rendering;
using Steelforge.Misc;

namespace Steelforge.Core.States
{
    public abstract class StateBase
    {
        public static EmptyState _empty = new EmptyState();
        private bool needsExtendedUpdate = false;

        // Macro that executes when something inherits from StateBase
        static int states = 0; // Keeps track of how many statebase instances there are.
        public StateBase()
        {
            // Set stateID of instance and increment
            stateID = states;
            states++;

        }

        // Return state identification
        private int stateID;
        public int GetID()
        {
            return stateID;

        }

        protected void RequestExtendedUpdate()
        {
            this.needsExtendedUpdate = true;

        }

        public bool WantsExtendedUpdate()
        {
            return this.needsExtendedUpdate;

        }

        // Init
        public abstract void Init(RenderWindow window);

        // Core
        public abstract void Update(Time time);
        public virtual void LateUpdate(Time time) { }

        // Does the StateBase want control over the RenderWindow?
        // Let them have it
        protected virtual void Update(Time time, RenderWindow window) { }
        public void ExtendedUpdate(Time time, RenderWindow window)
        {
            Update(time, window);
            this.needsExtendedUpdate = false;

        }

        public abstract void FixedUpdate(Time time);
        public abstract void Render(ref Buffer bufferOut);
        public virtual void SendLine(string s) { }

        // Input
        public virtual void MouseMoved(object sender, MouseMoveEventArgs e) { }
        public virtual void MouseScrolled(object sender, MouseWheelEventArgs e) { }

        protected void Close()
        {
            Engine.Push(Command.Close);

        }
    }
}
