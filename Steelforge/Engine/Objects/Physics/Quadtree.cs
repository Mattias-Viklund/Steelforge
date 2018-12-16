using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace Steelforge.Objects.Physics
{
    public class Quadtree
    {
        private int MAX_OBJECTS = 10;
        private int MAX_LEVELS = 5;

        private int level;
        private List<GameObject> objects;
        private FloatRect bounds;
        private Quadtree[] nodes;

        public Quadtree(int pLevel, FloatRect pBounds)
        {
            level = pLevel;
            objects = new List<GameObject>();
            bounds = pBounds;
            nodes = new Quadtree[4];

        }

        public void Clear()
        {
            objects.Clear();

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] != null)
                {
                    nodes[i].Clear();
                    nodes[i] = null;
                }
            }
        }

        private void Split()
        {
            int subWidth = (int)(bounds.Width / 2);
            int subHeight = (int)(bounds.Height / 2);
            int x = (int)bounds.Left;
            int y = (int)bounds.Top;

            nodes[0] = new Quadtree(level + 1, new FloatRect(x + subWidth, y, subWidth, subHeight));
            nodes[1] = new Quadtree(level + 1, new FloatRect(x, y, subWidth, subHeight));
            nodes[2] = new Quadtree(level + 1, new FloatRect(x, y + subHeight, subWidth, subHeight));
            nodes[3] = new Quadtree(level + 1, new FloatRect(x + subWidth, y + subHeight, subWidth, subHeight));

        }

        public void Insert(GameObject pRect)
        {
            if (nodes[0] != null)
            {
                int index = GetIndex(pRect.GetHitbox());

                if (index != -1)
                {
                    nodes[index].Insert(pRect);

                    return;
                }
            }

            objects.Add(pRect);

            if (objects.Count > MAX_OBJECTS && level < MAX_LEVELS)
            {
                if (nodes[0] == null)
                {
                    Split();

                }

                int i = 0;
                while (i < objects.Count)
                {
                    int index = GetIndex(objects[i].GetHitbox());
                    if (index != -1)
                    {
                        nodes[index].Insert(objects[i]);
                        objects.RemoveAt(i);

                    }
                    else
                    {
                        i++;

                    }
                }
            }
        }

        private int GetIndex(FloatRect pRect)
        {
            int index = -1;
            double verticalMidpoint = bounds.Left + (bounds.Width / 2);
            double horizontalMidpoint = bounds.Top + (bounds.Height / 2);

            // Object can completely fit within the top quadrants
            bool topQuadrant = (pRect.Top < horizontalMidpoint && pRect.Top + pRect.Height < horizontalMidpoint);

            // Object can completely fit within the bottom quadrants
            bool bottomQuadrant = (pRect.Top > horizontalMidpoint);

            // Object can completely fit within the left quadrants
            if (pRect.Left < verticalMidpoint && pRect.Left + pRect.Width < verticalMidpoint)
            {
                if (topQuadrant)
                {
                    index = 1;

                }
                else if (bottomQuadrant)
                {
                    index = 2;

                }
            }
            // Object can completely fit within the right quadrants
            else if (pRect.Left > verticalMidpoint)
            {
                if (topQuadrant)
                {
                    index = 0;

                }
                else if (bottomQuadrant)
                {
                    index = 3;

                }
            }
            return index;

        }
    }
}
