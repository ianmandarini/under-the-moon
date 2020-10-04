using System;
using UnityEngine;

namespace Movement
{
    [CreateAssetMenu(menuName = "Custom/MovementSO")]
    public sealed class MovementSO: ScriptableObject
    {
        public bool CanMove { get; private set; }
        public bool IsGrounded { get; set; }

        public void AllowMovement() => this.CanMove = true;
        public void BlockMovement() => this.CanMove = false;


        public event EventHandler<PlayerAnimationStateEventArgs> MovementStateUpdated;

        public void OnMovementStateUpdated(PlayerAnimationStateEventArgs e)
        {
            this.MovementStateUpdated?.Invoke(this, e);
        }
    }
}