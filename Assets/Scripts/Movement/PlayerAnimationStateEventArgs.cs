using System;

namespace Movement
{
    public class PlayerAnimationStateEventArgs: EventArgs
    {
        public float LastInputAxisHorizontal { get; }
        public float CurrentInputHorizontalAxis { get; }

        public PlayerAnimationStateEventArgs(float lastInputAxisHorizontal, float currentInputHorizontalAxis)
        {
            this.LastInputAxisHorizontal = lastInputAxisHorizontal;
            this.CurrentInputHorizontalAxis = currentInputHorizontalAxis;
        }
    }
}