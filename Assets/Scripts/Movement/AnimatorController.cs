using UnityEngine;

namespace Movement
{
    public class AnimatorController: MonoBehaviour
    {
        [SerializeField] private Animator animator = default;

        public void Resume()
        {
            this.animator.speed = 1.0f;
        }

        public void Pause()
        {
            this.animator.speed = 0.0f;
        }
    }
}