using System;
using UnityEngine;

namespace LoopTime
{
    [CreateAssetMenu(menuName = "Custom/TimeSO")]
    public sealed class TimeSO: ScriptableObject
    {
        public event EventHandler<TimeTickedEventArgs> TimeTicked;

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
            }
        }

        private void OnTimeTicked(TimeTickedEventArgs e)
        {
            this.TimeTicked?.Invoke(this, e);
        }
    }
}