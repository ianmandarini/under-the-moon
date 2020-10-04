using System;
using UnityEngine;

namespace Input
{
    [CreateAssetMenu(menuName = "Custom/InputSO")]
    public sealed class InputSO: ScriptableObject
    {
        public event EventHandler Interacted;
        public float HorizontalAxis { get; private set; }
        public bool IsRunning { get; private set; }
        public event EventHandler PickedOrDroppedItem;
        public event EventHandler Jumped;

        public void Tick()
        {
            if(UnityEngine.Input.GetButtonDown(Constants.InteractButton))
                this.OnInteracted();
            if(UnityEngine.Input.GetButtonDown(Constants.Jumped))
                this.OnJumped();
            if(UnityEngine.Input.GetButtonDown(Constants.PickOrDropItemButton))
                this.OnPickedOrDroppedItem();
            this.HorizontalAxis = UnityEngine.Input.GetAxis(Constants.HorizontalAxis);
            this.IsRunning = UnityEngine.Input.GetButton(Constants.RunButton);
        }

        private void OnInteracted() => this.Interacted?.Invoke(this, EventArgs.Empty);

        private void OnPickedOrDroppedItem() => this.PickedOrDroppedItem?.Invoke(this, EventArgs.Empty);

        private void OnJumped() => this.Jumped?.Invoke(this, EventArgs.Empty);
    }
}