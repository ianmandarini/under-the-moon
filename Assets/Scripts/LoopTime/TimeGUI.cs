using System;
using TMPro;
using UnityEngine;

namespace LoopTime
{
    public class TimeGUI: MonoBehaviour
    {
        [SerializeField] private TMP_Text textGUI = default;
        [SerializeField] private TimeSO timeSO = default;

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
            int percentage = (int) (e.ToT * 100.0f);
            this.textGUI.text = percentage + "%";
        }
    }
}