using System;
using Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Misc
{
    public class PressStartToChangeScene: MonoBehaviour
    {
        [SerializeField] private InputSO inputSO = default;
        [SerializeField] private string sceneName = default;
        
        private void OnEnable()
        {
            this.inputSO.PressedStart += this.PressedStartEventHandler;
        }

        private void OnDisable()
        {
            this.inputSO.PressedStart -= this.PressedStartEventHandler;
        }

        private void PressedStartEventHandler(object sender, EventArgs e)
        {
            SceneManager.LoadScene(this.sceneName);
        }
    }
}