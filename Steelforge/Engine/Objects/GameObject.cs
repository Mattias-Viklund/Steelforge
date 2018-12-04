using SFML.System;
using Steelforge.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Objects
{
    public class GameObject
    {
        public static List<GameObject> gameObjects = new List<GameObject>();
        private static int IDs = 0;

        protected Vector2f position;
        private bool lerp = false;
        private int[] lerps = new int[2];
        private int ID;

        public GameObject(bool macro=true)
        {
            if (macro)
            {
                gameObjects.Add(this);
                this.ID = IDs;
                IDs++;

            }
        }

        public Vector2f GetPosition()
        {
            return position;

        }

        public void SetPosition(Vector2f position)
        {
            this.position = position;

        }

        public void Update()
        {
            if (lerp)
            {
                Interp interp;
                for (int i = 0; i < 2; i++)
                {
                    interp = Engine.interpolator.GetInterp(lerps[i]);
                    if (interp == null)
                    {
                        continue;
                    }
                    else
                    {
                        if (interp.IsDone())
                        {
                            lerp = false;
                            break;

                        }

                        float value = interp.GetValue();
                        Console.WriteLine("value: " + value);

                        if (i == 0)
                        {
                            position.X += value;

                        }
                        else
                        {
                            position.Y += value;

                        }
                    }
                }
            }
        }

        public void LerpPosition(Vector2f end, int milliseconds)
        {
            // Lerp1
            lerps[0] = Interpolation.Lerp(0, end.X, milliseconds);
            lerps[1] = Interpolation.Lerp(0, end.Y, milliseconds);
            lerp = true;

        }

        public static void Destroy(int index)
        {
            gameObjects.RemoveAt(index);

        }
    }
}
