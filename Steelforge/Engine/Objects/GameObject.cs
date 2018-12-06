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

        public void UpdateObject()
        {
            
        }

        public static void Destroy(int index)
        {
            gameObjects.RemoveAt(index);

        }
    }
}
