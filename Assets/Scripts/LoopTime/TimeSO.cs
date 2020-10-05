using System;
using UnityEngine;

namespace LoopTime
{
    [CreateAssetMenu(menuName = "Custom/TimeSO")]
    public sealed class TimeSO: ScriptableObject
    {
        public event EventHandler<TimeTickedEventArgs> TimeTicked;
        public event EventHandler TimeEnded;

        private float _timeT = 0.0f;

        public float TimeT
        {
            get => this._timeT;
            set
            {
                float fromT = this._timeT;
                float toT = value;
                this._timeT = toT;
                this.OnTimeTicked(new TimeTickedEventArgs(fromT, toT));
                if (toT >= 1.0f)
                    this.OnTimeEnded();
            }
        }

        private void OnTimeTicked(TimeTickedEventArgs e)
        {
            this.TimeTicked?.Invoke(this, e);
        }

        private void OnTimeEnded()
        {
            this.TimeEnded?.Invoke(this, EventArgs.Empty);
        }
    }
}