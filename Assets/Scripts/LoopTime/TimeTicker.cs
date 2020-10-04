using System;
using UnityEngine;

namespace LoopTime
{
    public class TimeTicker: MonoBehaviour
    {
        [SerializeField] private float maxTime = 3600.0f;
        [SerializeField] private TimeSO timeSO = default;
        
        private float _currentTime = 0.0f;

        private void Start()
        {
            this._currentTime = 0.0f;
            this.timeSO.TimeT = 0.0f;
        }

        private void Update()
        {
            this.PassTime(Time.deltaTime);
        }

        private void PassTime(float deltaTime)
        {
            this._currentTime += Time.deltaTime;
            this.timeSO.TimeT = this._currentTime / this.maxTime;
        }
    }
}