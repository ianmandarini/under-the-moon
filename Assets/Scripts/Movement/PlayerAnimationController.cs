using System;
using Extensions;
using UnityEngine;

namespace Movement
{
    public class PlayerAnimationController: MonoBehaviour
    {
        [SerializeField] private MovementSO movementSO = default;
        
        [SerializeField] private GameObject playerHand = default;
        [SerializeField] private SpriteRenderer playerRenderer = default;
        [SerializeField] private AnimatorController walkAnimatorController = default;

        private bool FlipPlayer
        {
            set
            {
                this.playerRenderer.flipX = value;

                Vector3 pos = this.playerHand.transform.localPosition;
                pos.x = (value ? -1.0f : 1.0f) * pos.x.Magnitude();
                this.playerHand.transform.localPosition = pos;

            }
        }

        private void OnEnable()
        {
            this.movementSO.MovementStateUpdated += this.MovementStateUpdatedEventHandler;
        }

        private void MovementStateUpdatedEventHandler(object sender, PlayerAnimationStateEventArgs e)
        {
            this.UpdateAccordingToState(e);
        }

        private void UpdateAccordingToState(PlayerAnimationStateEventArgs stateEventArgs)
        {
            this.FlipPlayer = stateEventArgs.LastInputAxisHorizontal < 0.0f;
            
            if(stateEventArgs.CurrentInputHorizontalAxis.Magnitude() > 0.01f)
                this.walkAnimatorController.Resume();
            else
                this.walkAnimatorController.Pause();
        }
    }
}