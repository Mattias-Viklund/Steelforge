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

        public static void Lerp(float start, float end, int milliseconds)
        {
            Engine.interpolator.AddInterpolator(new Interp(Interp.InterpolationType.Lerp, start, end, milliseconds));

        }
    }

    public struct Interp
    {
        public enum InterpolationType
        {
            Lerp,
            Slerp,
            Nlerp

        }

        private InterpolationType interpType;
        private int millisecondsRemaining;

        private float differencePerMS;
        private float value;

        private int ID;

        public Interp(InterpolationType interpType, float start, float end, int durationMilliseconds)
        {
            millisecondsRemaining = durationMilliseconds;
            this.interpType = interpType;
            this.value = start;

            if (start - end != 0)
                differencePerMS = durationMilliseconds / (start - end);
            else
                differencePerMS = 0;

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
    }
}
