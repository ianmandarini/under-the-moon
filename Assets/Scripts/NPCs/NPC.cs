using System;
using Dialogue;
using Extensions;
using Input;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace NPCs
{
    [RequireComponent(typeof(Collider2D))]
    public class NPC: MonoBehaviour
    {
        [SerializeField] private Dialogue.Dialogue dialogue = default;
        [SerializeField] private GameObject interactionIndicator = default;
        [SerializeField] private InputSO inputSO = default;
        [SerializeField] private DialogueSO dialogueSO = default;
        [SerializeField] private NPCSO npcso = default;
    
        private bool _isPlayerInside = false;

        private bool IsPlayerInside
        {
            get => this._isPlayerInside;
            set => this._isPlayerInside = value;
        }

        private void Update()
        {
            if(this.IsPlayerInside && !this.dialogueSO.IsInDialogue)
                this.interactionIndicator.SetActive(true);
            else
                this.interactionIndicator.SetActive(false);
        }

        private void Start()
        {
            this.IsPlayerInside = false;
        }

        private void OnEnable()
        {
            this.inputSO.Interacted += this.InteractedEventHandler;
        }

        private void OnDisable()
        {
            this.inputSO.Interacted -= this.InteractedEventHandler;
        }

        private void InteractedEventHandler(object sender, EventArgs e)
        {
            if(this.IsPlayerInside && this.npcso.CanInteract)
                this.Interact();
        }

        private void Interact()
        {
            this.dialogueSO.StartDialogue(this.dialogue);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.IsPlayer())
                this.IsPlayerInside = true;
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.IsPlayer())
                this.IsPlayerInside = false;
        }
    }
}