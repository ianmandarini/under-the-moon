using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueView: MonoBehaviour
    {
        [SerializeField] private Canvas dialogueCanvas = default;
        [SerializeField] private Image faceImageGUI = default;
        [SerializeField] private TMP_Text mainTextGUI = default;
        [SerializeField] private DialogueSO dialogueSO = default;

        private void Start()
        {
            this.dialogueCanvas.enabled = false;
        }

        private void OnEnable()
        {
            this.dialogueSO.DialogueStarted += this.DialogueStartedEventHandler;
            this.dialogueSO.DialogueEnded += this.DialogueEndedEventHandler;
            this.dialogueSO.LineUpdated += this.DialogueLineUpdatedEventHandler;
        }
        
        private void OnDisable()
        {
            this.dialogueSO.DialogueStarted -= this.DialogueStartedEventHandler;
            this.dialogueSO.DialogueEnded -= this.DialogueEndedEventHandler;
            this.dialogueSO.LineUpdated -= this.DialogueLineUpdatedEventHandler;
        }

        private void DialogueStartedEventHandler(object sender, EventArgs e)
        {
            this.dialogueCanvas.enabled = true;
        }

        private void DialogueEndedEventHandler(object sender, EventArgs e)
        {
            this.dialogueCanvas.enabled = false;
        }

        private void DialogueLineUpdatedEventHandler(object sender, CurrentLineEventArgs e)
        {
            this.faceImageGUI.sprite = e.Sprite;
            this.mainTextGUI.text = e.Text;
        }
    }
}