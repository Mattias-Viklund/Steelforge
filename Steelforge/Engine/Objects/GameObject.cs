using SFML.Graphics;
using SFML.System;
using Steelforge.Core;
using Steelforge.Objects.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Objects
{
    public class GameObject : GameDrawable
    {
        public static List<GameObject> gameObjects = new List<GameObject>();

        // If it has no index, set it to -1
        private int index = -1;

        protected bool enabled = true;

        protected Vector2f position;
        protected string name;

        private bool hasHitbox = false;
        protected FloatRect hitbox;

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

        public void SetPosition(Vector2f position, bool add = false)
        {
            if (add)
                this.position += position;
            else
                this.position = position;

        }

        public bool HasHitbox()
        {
            return hasHitbox;

        }

        public FloatRect GetHitbox()
        {
            return hitbox;

        }

        public void SetHitbox(FloatRect hitbox)
        {
            this.hitbox = hitbox;
            this.hasHitbox = true;

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

        public virtual void DrawObject(RenderTexture texture, RenderStates state)
        {


        }
    }
}
