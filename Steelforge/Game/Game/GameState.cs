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
using Steelforge.Core.World;
using Steelforge.Maths;

namespace Steelforge.Game
{
    class GameState : StateBase
    {
        private DrawBuffer queue;

        // Keep track of the screen
        private Vector2u size;
        private Vector2u center;


        private float fov = (float)(Math.PI / 2);
        public Vector3f camPosition = new Vector3f(0, -2, 0); //position of the camera
        public double direction = (float)(Math.PI / 8); //direction counter-clockwise around the Z-axis
        public float rotationY = 0;
        public float speed = 0.005f;
        public float mouseSpeed = -1f;
        public Cube cube = new Cube(new Vector3f(6, 0, 0), 2);

        public GameState(int drawLimit)
        {
            queue = new DrawBuffer(drawLimit);

        }

        public override void Init(RenderWindow window)
        {
            this.size = window.Size;
            this.center = new Vector2u(size.X / 2, size.Y / 2);

        }

        public override void Update(Time time)
        {

        }

        public override void FixedUpdate(Time time)
        {
            queue.Clear();
            Draw(time);
            InputManager.MOUSE_VELOCITY = GlobalConstants.VEC2F_ZERO;

        }

        private void Line(Vector2f p1, Vector2f p2)
        {
            VertexArray v1 = new VertexArray(PrimitiveType.Lines);
            v1.Append(new Vertex(p1, Color.White));
            v1.Append(new Vertex(p2, Color.White));

            queue.Add(new GameRenderable(v1));

        }

        public void Draw(Time time)
        {
            //turning with the mouse
            direction += (InputManager.MOUSE_VELOCITY.X) * mouseSpeed * 2 * fov / size.X;
            while (direction >= 2 * Math.PI) direction -= 2 * Math.PI;
            while (direction < 2 * Math.PI) direction += 2 * Math.PI;

            rotationY -= (InputManager.MOUSE_VELOCITY.Y) * mouseSpeed * 2 * fov / size.Y;
            if (rotationY > Math.PI / 2) rotationY = (float)Math.PI / 2;
            if (rotationY < -Math.PI / 2) rotationY = (float)-Math.PI / 2;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                base.Close();

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                camPosition = Vectors.Relative(camPosition, (float)(speed * Math.Cos(direction)), (float)(speed * Math.Sin(direction)), 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                camPosition = Vectors.Relative(camPosition, (float)(-speed * Math.Cos(direction)), (float)(-speed * Math.Sin(direction)), 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                camPosition = Vectors.Relative(camPosition, (float)(-speed * Math.Sin(direction)), (float)(speed * Math.Cos(direction)), 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                camPosition = Vectors.Relative(camPosition, (float)(speed * Math.Sin(direction)), (float)(-speed * Math.Cos(direction)), 0);

            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift))
                camPosition = Vectors.Relative(camPosition, 0, 0, -speed);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                camPosition = Vectors.Relative(camPosition, 0, 0, speed);

            //little crosshair
            Line(new Vector2f(size.X / 2 - 5, size.Y / 2), new Vector2f(size.X / 2 + 5, size.Y / 2));
            Line(new Vector2f(size.X / 2, size.Y / 2 - 5), new Vector2f(size.X / 2, size.Y / 2 + 5));

            //loop to draw all of our wires on the screen
            for (int i = 0; i < cube.Wires.Length; i++)
            {

                //wires end and start positions transformed to camera coordinates
                Vector3f camPosStart = ToCamCoords(cube.Wires[i].start);
                Vector3f camPosEnd = ToCamCoords(cube.Wires[i].end);

                //projection of start and endpoints to camera
                Vector3f drawStart = PointOnCanvas(camPosStart);
                Vector3f drawEnd = PointOnCanvas(camPosEnd);

                //drawing lines on screen
                Line(new Vector2f(drawStart.X, drawStart.Y), new Vector2f(drawEnd.X, drawEnd.Y));

            }
        }

        public Vector3f PointOnCanvas(Vector3f pos)
        {

            float angleH = (float)Math.Atan2(pos.Y, pos.X);
            float angleV = (float)Math.Atan2(pos.Z, pos.X);

            angleH /= (float)Math.Abs(Math.Cos(angleH));
            angleV /= (float)Math.Abs(Math.Cos(angleV));

            return new Vector3f(size.X / 2 - angleH * size.X / fov, size.Y / 2 - angleV * size.X / fov, 0);
        }

        public Vector3f ToCamCoords(Vector3f pos)
        {
            Vector3f rPos = new Vector3f(pos.X - camPosition.X, pos.Y - camPosition.Y, pos.Z - camPosition.Z);
            //calculating rotation
            float rx = rPos.X;
            float ry = rPos.Y;
            float rz = rPos.Z;

            //rotation Z-axis
            rPos.X = (float)(rx * Math.Cos(-direction) - ry * Math.Sin(-direction));
            rPos.Y = (float)(rx * Math.Sin(-direction) + ry * Math.Cos(-direction));

            //rotation Y-axis
            rx = rPos.X;
            rz = rPos.Z;
            rPos.X = (float)(rx * Math.Cos(-rotationY) + rz * Math.Sin(-rotationY));
            rPos.Z = (float)(rz * Math.Cos(-rotationY) - rx * Math.Sin(-rotationY));

            return rPos;
        }

        public override DrawBuffer Render()
        {
            return queue;

        }
    }
}
