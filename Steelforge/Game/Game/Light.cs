using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Steelforge.Rendering;
using Steelforge.Core;

namespace Steelforge.Game
{
    class Light
    {
        public Color color;
        public Vector2f position;
        public float radius;

        public List<VertexArray> arrs = new List<VertexArray>();

        public Light(Color color, Vector2f position, float radius)
        {
            this.color = color;
            this.position = position;
            this.radius = radius;

        }

        public void Move(Vector2f position)
        {
            this.position = position;

        }

        public void Clear()
        {
            arrs.Clear();

        }

        public void Draw(ref DrawBuffer buffer)
        {
            foreach (VertexArray arr in arrs)
            {
                buffer.Add(new GameRenderable(arr));

            }
        }

        public VertexArray GetLight(VertexArray arr)
        {
            Vertex v1 = arr[0];
            Vertex v2 = arr[1];

            VertexArray sArray = new VertexArray(PrimitiveType.Lines);
            sArray.Append(new Vertex(v1.Position, Color.White));
            sArray.Append(new Vertex(this.position, Color.White));

            sArray.Append(new Vertex(v2.Position, Color.White));
            sArray.Append(new Vertex(this.position, Color.White));

            arrs.Add(sArray);

            float dist1 = radius / Maths.Vectors.Distance(this.position, v1.Position);
            float dist2 = radius / Maths.Vectors.Distance(this.position, v2.Position);

            dist1 = dist1 > 1 ? 1 : dist1;
            dist2 = dist2 > 1 ? 1 : dist2;

            float isqr1 = dist1;
            float isqr2 = dist2;

            byte br1, bg1, bb1, ba1;
            byte br2, bg2, bb2, ba2;

            br1 = v1.Color.R;
            bg1 = v1.Color.G;
            bb1 = v1.Color.B;
            ba1 = v1.Color.A;

            br2 = v2.Color.R;
            bg2 = v2.Color.G;
            bb2 = v2.Color.B;
            ba2 = v2.Color.A;

            br1 = (byte)(0 + (br1 * Math.Abs(isqr1)));
            bg1 = (byte)(0 + (bg1 * Math.Abs(isqr1)));
            bb1 = (byte)(0 + (bb1 * Math.Abs(isqr1)));
            ba1 = (byte)(0 + (ba1 * Math.Abs(isqr1)));
                           
            br2 = (byte)(0 + (br2 * Math.Abs(isqr2)));
            bg2 = (byte)(0 + (bg2 * Math.Abs(isqr2)));
            bb2 = (byte)(0 + (bb2 * Math.Abs(isqr2)));
            ba2 = (byte)(0 + (ba2 * Math.Abs(isqr2)));

            Color clr1 = new Color(br1, bg1, bb1, ba1);
            Color clr2 = new Color(br2, bg2, bb2, ba2);

            VertexArray arr2 = new VertexArray(PrimitiveType.Lines);
            arr2.Append(new Vertex(v1.Position, clr1));
            arr2.Append(new Vertex(v2.Position, clr2));

            return arr2;

        }

        public float InvSqrt(float x, int iterations = 1)
        {
            Convert convert = new Convert();
            convert.x = x;
            float xhalf = 0.5f * x;
            float twoThird = 1.5f;
            convert.i = 0x5f3759df - (convert.i >> 1);
            x = convert.x;
            x = x * (twoThird - xhalf * x * x);

            for (int i = 0; i < iterations; i++)
            {
                x = x * (twoThird - xhalf * x * x);

            }

            return x;

        }

        [StructLayout(LayoutKind.Explicit)]
        private struct Convert
        {
            [FieldOffset(0)]
            public float x;

            [FieldOffset(0)]
            public int i;
        }
    }
}
