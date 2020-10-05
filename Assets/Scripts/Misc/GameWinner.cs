using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Misc
{
    public class GameWinner: MonoBehaviour
    {
        [SerializeField] private string sceneName = default;
        [SerializeField] private float waitTime = default;

        private void WinGame()
        {
            SceneManager.LoadScene(this.sceneName);
        }
        
        public void WinGameAfterTime()
        {
            this.StartCoroutine(this.WinGameAfterTimeCoroutine());
        }

        private IEnumerator WinGameAfterTimeCoroutine()
        {
            yield return new WaitForSeconds(this.waitTime);
            this.WinGame();
        }
    }
}