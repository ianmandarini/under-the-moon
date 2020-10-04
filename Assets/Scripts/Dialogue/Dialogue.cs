using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(menuName = "Custom/Dialogue")]
    public class Dialogue: ScriptableObject
    {
        [SerializeField] private bool hasSprite = default;
        [SerializeField] private Sprite faceSprite = default;
        [SerializeField] private List<string> dialogueLines = default;

        private int _currentLine = 0;
        private bool _hasEnded;

        private int CurrentLine
        {
            get => this._currentLine;
            set
            { 
                this._currentLine = value;
                this._hasEnded = this.dialogueLines.HasIndex(this._currentLine);
            }
        }

        public bool HasEnded => this._hasEnded;
        public bool HasSprite => this.hasSprite;
        public Sprite Sprite => this.faceSprite;

        public void Start() => this.CurrentLine = 0;
        public void Next() => this.CurrentLine++;

        public string CurrentLineText => this.HasEnded ? "" : this.dialogueLines[this.CurrentLine];
    }
}