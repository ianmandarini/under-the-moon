using System;
using UnityEngine;
using UnityEngine.Events;

namespace LoopTime
{
    public class TimeWatcher: MonoBehaviour
    {
        [SerializeField] private TimeSO timeSO = default;
        [SerializeField] [Range(0, 1)] private float triggerT = 0.5f;
        [SerializeField] private UnityEvent triggered = default;

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
            if (e.FromT < this.triggerT && e.ToT >= this.triggerT)
                this.TriggeredThis();
        }

        private void TriggeredThis()
        {
            this.triggered.Invoke();
        }
    }
}