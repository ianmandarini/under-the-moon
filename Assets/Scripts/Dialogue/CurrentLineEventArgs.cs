using System;
using UnityEngine;

namespace Dialogue
{
    public class CurrentLineEventArgs: EventArgs
    {
        private CurrentLineEventArgs(bool hasSprite, Sprite sprite, string text)
        {
            this.HasSprite = hasSprite;
            this.Sprite = sprite;
            this.Text = text;
        }

        public Sprite Sprite { get; }
        public bool HasSprite { get; }
        public string Text { get; }

        public static CurrentLineEventArgs FromDialogue(global::Dialogue.Dialogue dialogue)
        {
            return new CurrentLineEventArgs(dialogue.HasSprite, dialogue.Sprite, dialogue.CurrentLineText);
        }
    }
}