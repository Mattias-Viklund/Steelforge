using SFML.Graphics;
using SFML.System;
using Steelforge.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Objects
{
    public class GameObject : Drawable
    {
        public static List<GameObject> gameObjects = new List<GameObject>();

        protected Vector2f position;
        protected bool enabled = true;

        private int index = -1;

        public GameObject(bool macro = true)
        {
            if (macro)
            {
                gameObjects.Add(this);
                this.index = gameObjects.Count - 1;

            }
        }

        public int GetIndex()
        {
            return index;

        }

        public Vector2f GetPosition()
        {
            return position;

        }

        public void SetPosition(Vector2f position)
        {
            this.position = position;

        }

        /// <summary>
        /// Special need to update a specific object?
        /// </summary>
        public virtual void Update()
        {


        }

        public static void Create(GameObject gameObject)
        {
            gameObjects.Add(gameObject);

        }

        public static GameObject GetByIndex(int index)
        {
            if (WithinBounds(index))
                return gameObjects[index];

            return null;

        }

        public static void Destroy(int index)
        {
            if (WithinBounds(index))
                gameObjects[index].enabled = false;

        }

        private static bool WithinBounds(int index)
        {
            if (index < 0 || index > gameObjects.Count - 1)
                return false;

            return true;

        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            if (target is RenderWindow)
            {
                Draw((target as RenderWindow), states);

            }
        }
        
        public virtual void Draw(RenderWindow window, RenderStates states)
        {


        }
    }
}
