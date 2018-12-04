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
        private List<int> ids = new List<int>();

        public void AddInterpolator(Interp interp)
        {
            interpolations.Add(interp);
            ids.Add(interp.GetID());

        }

        public void StepAll(int milliseconds)
        {
            for (int i = 0; i < interpolations.Count; i++)
            {
                if (interpolations[i].Step(milliseconds))
                {
                    interpolations.RemoveAt(i);
                    ids.RemoveAt(i);

                    // If we removed an item, make sure we don't miss another item
                    i--;

                }
            }
        }

        public int GetInterps()
        {
            return interpolations.Count;

        }

        public Interp GetInterp(int ID)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                if (ids[i] == ID)
                    return interpolations[i];

            }
            return null;

        }
    }
}
