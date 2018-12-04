using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Core
{
    static class Interpolation
    {
        private static float Lerp(float start, float end, float percent)
        {
            return (start + percent * (end - start));

        }

        public static int Lerp(float start, float end, int milliseconds)
        {
            Interp interpolation = new Interp(start, end, milliseconds);
            int ID = interpolation.GetID();
            Engine.interpolator.AddInterpolator(interpolation);

            return ID;

        }
    }

    public class Interp
    {
        private static Random randomNumberGenerator = new Random();

        private int millisecondsRemaining;

        private float differencePerMS;
        private float value;

        private int ID;

        public Interp(float start, float end, int durationMilliseconds)
        {
            millisecondsRemaining = durationMilliseconds;
            this.value = start;

            if (start - end != 0)
                differencePerMS = durationMilliseconds / (start - end);
            else
            {
                differencePerMS = 0;
                millisecondsRemaining = 0;

            }
            this.ID = randomNumberGenerator.Next();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="milliseconds">Milliseconds since last update</param>
        /// <returns></returns>
        public bool Step(int milliseconds)
        {
            if (differencePerMS == 0)
                return true;

            value += differencePerMS * milliseconds;

            millisecondsRemaining -= milliseconds;

            if (milliseconds <= 0)
                return true;

            return false;

        }

        public int GetID()
        {
            return this.ID;

        }

        public float GetValue()
        {
            return value;

        }

        public bool IsDone()
        {
            return (millisecondsRemaining <= 0);

        }
    }
}
