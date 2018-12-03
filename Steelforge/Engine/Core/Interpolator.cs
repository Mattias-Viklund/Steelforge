using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Core
{
    public class Interpolator
    {
        private List<Interp> interpolations = new List<Interp>();

        public void AddInterpolator(Interp interp)
        {
            interpolations.Add(interp);

        }

        public void StepAll(int milliseconds)
        {
            for (int i = 0; i < interpolations.Count; i++)
            {
                if (interpolations[i].Step(milliseconds))
                {
                    interpolations.RemoveAt(i);

                    // If we removed an item, make sure we don't miss another item
                    i--;

                }
            }
        }
    }
}
