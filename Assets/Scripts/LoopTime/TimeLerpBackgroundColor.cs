using System;
using UnityEngine;

namespace LoopTime
{
    public class TimeLerpBackgroundColor: MonoBehaviour
    {
        [SerializeField] private TimeSO timeSO = default;
        [SerializeField] private Camera target = default;
        [SerializeField] private Gradient gradient = default;

        private void OnEnable()
        {
            this.timeSO.TimeTicked += this.TimeTickedEventHandler;
        }

        private void OnDisable()
        {
            this.timeSO.TimeTicked -= this.TimeTickedEventHandler;
        }

        private void TimeTickedEventHandler(object sender, TimeTickedEventArgs e)
        {
            this.target.backgroundColor = this.gradient.Evaluate(e.ToT);
        }
    }
}