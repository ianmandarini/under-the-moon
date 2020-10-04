using System;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(menuName = "Custom/DialogueSO")]
    public sealed class DialogueSO: ScriptableObject
    {
        public event EventHandler<CurrentLineEventArgs> LineUpdated;
        public event EventHandler DialogueEnded;
        public event EventHandler DialogueStarted;

        private Dialogue _currentDialogue;
        private bool _isInDialogue;

        public bool IsInDialogue
        {
            get => this._isInDialogue;
            set => this._isInDialogue = value;
        }

        public bool HasJustStarted { get; set; }

        public void StartDialogue(Dialogue dialogue)
        {
            this.HasJustStarted = true;
            this._currentDialogue = dialogue;
            this._currentDialogue.Start();
            this.OnDialogueStarted();
            this.EmitEvents();
            this.IsInDialogue = true;
        }

        public void Next()
        {
            this._currentDialogue.Next();
            this.EmitEvents();
        }

        private void EmitEvents()
        {
            if (this._currentDialogue.HasEnded)
                this.EndDialogue();
            else
                this.UpdateLine();
        }

        private void EndDialogue()
        {
            this.IsInDialogue = false;
            this._currentDialogue = null;
            this.OnDialogueEnded();
        }

        private void UpdateLine()
        {
            this.OnLineUpdated(CurrentLineEventArgs.FromDialogue(this._currentDialogue));
        }

        private void OnDialogueEnded()
        {
            this.DialogueEnded?.Invoke(this, EventArgs.Empty);
        }

        private void OnLineUpdated(CurrentLineEventArgs e)
        {
            this.LineUpdated?.Invoke(this, e);
        }

        private void OnDialogueStarted()
        {
            this.DialogueStarted?.Invoke(this, EventArgs.Empty);
        }
    }
}