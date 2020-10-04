using UnityEngine;

namespace Input
{
    public class InputRunner: MonoBehaviour
    {
        [SerializeField] private InputSO inputSO = default;

        private void Update()
        {
            this.inputSO.Tick();
        }
    }
}