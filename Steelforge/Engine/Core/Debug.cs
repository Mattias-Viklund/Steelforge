using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Core
{
    public static class Debug
    {
        private static string[] waiting = new string[Console.BufferHeight];
        private static int writeTo = 0;

        public static void Write(string s)
        {
            if (writeTo == waiting.Length)
            {
                Flush();
                writeTo = 0;

            }

            waiting[writeTo] = s;
            writeTo++;

        }

        public static void Flush()
        {
            if (writeTo == 0)
                return;

            for (int i = writeTo; i > 0; i--)
            {
                Console.Out.WriteLine(waiting[i - 1]);

            }
            writeTo = 0;

        }
    }
}
