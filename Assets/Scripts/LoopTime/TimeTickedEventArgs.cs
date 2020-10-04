using System;

namespace LoopTime
{
    public class TimeTickedEventArgs: EventArgs
    {
        public TimeTickedEventArgs(float fromT, float toT)
        {
            this.FromT = fromT;
            this.ToT = toT;
        }

        public float FromT { get; }
        public float ToT { get; }
    }
}