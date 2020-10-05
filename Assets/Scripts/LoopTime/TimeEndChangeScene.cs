using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoopTime
{
    public class TimeEndChangeScene: MonoBehaviour
    {
        [SerializeField] private TimeSO timeSO = default;
        [SerializeField] private string sceneName = default;

        private void OnEnable()
        {
            this.timeSO.TimeEnded += this.TimeEndedEventHandler;
        }

        private void OnDisable()
        {
            this.timeSO.TimeEnded -= this.TimeEndedEventHandler;
        }

        private void TimeEndedEventHandler(object sender, EventArgs e)
        {
            SceneManager.LoadScene(this.sceneName);
        }
    }
}