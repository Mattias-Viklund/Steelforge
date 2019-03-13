using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steelforge.Core
{
    class _EventHandler
    {
        public delegate void _Event();
        private _Event[] events = new _Event[10];
        private int[] timeLefts = new int[10];
        private int[] _timeLefts = new int[10]; // Repeat Timelefts
        private bool[] repeat = new bool[10];
        private int[] running = new int[10];

        public _EventHandler()
        {

        }

        public bool CreateEvent(int executeInMillis, _Event _event, bool repeat)
        {
            int index = FindNextAvailableIndex();

            if (index == -1)
                return false;

            events[index] = _event;
            timeLefts[index] = executeInMillis;
            _timeLefts[index] = executeInMillis;
            this.repeat[index] = repeat;
            running[index] = index;

            return true;

        }

        private int FindNextAvailableIndex()
        {
            for (int i = 0; i < running.Length; i++)
            {
                if (running[i] != 0)
                    return i;

            }

            return -1;

        }

        public void CheckEvents(Time time)
        {
            for (int i = 0; i < running.Length; i++)
            {
                if (running[i] != 0)
                    TickEvent(running[i], time);

            }
        }

        public void TickEvent(int index, Time time)
        {
            index = index - 1;

            timeLefts[index] -= time.AsMilliseconds();

            if (timeLefts[index] <= 0)
            {
                events[index]();
                if (repeat[index])
                {
                    timeLefts[index] = _timeLefts[index];

                }
                else
                {
                    timeLefts[index] = 0;
                    running[index] = 0;

                }
            }
        }
    }
}
