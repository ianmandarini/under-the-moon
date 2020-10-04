using System;
using Input;
using UnityEngine;

namespace Dialogue
{
    public class DialogueController: MonoBehaviour
    {
        [SerializeField] private InputSO inputSO = default;
        [SerializeField] private DialogueSO dialogueSO = default;
        
        private void OnEnable()
        {
            this.inputSO.Interacted += this.InputInteractedEventHandler;
        }
        
        private void OnDisable()
        {
            this.inputSO.Interacted -= this.InputInteractedEventHandler;
        }

        private void InputInteractedEventHandler(object sender, EventArgs e)
        {
            if(this.dialogueSO.IsInDialogue && !this.dialogueSO.HasJustStarted)
                this.dialogueSO.Next();
        }

        private void LateUpdate()
        {
            this.dialogueSO.HasJustStarted = false;
        }
    }
}