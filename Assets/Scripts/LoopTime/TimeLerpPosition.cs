using System;
using UnityEngine;

namespace LoopTime
{
    public class TimeLerpPosition: MonoBehaviour
    {
        [SerializeField] private TimeSO timeSO = default;
        [SerializeField] private GameObject target = default;
        [SerializeField] private Transform a = default;
        [SerializeField] private Transform b = default;
        
        private Vector3 _a;
        private Vector3 _b;

        private void Start()
        {
            this._a = this.a.transform.position;
            this._b = this.b.transform.position;
        }

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
            this.target.gameObject.transform.position = Vector3.Lerp(this._a, this._b, e.ToT);
        }
    }
}