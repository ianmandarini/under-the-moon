using System;
using UnityEngine;

namespace Items
{
    public class ItemPickedEventArgs: EventArgs
    {
        public ItemPickedEventArgs(Sprite itemSprite, string itemName, Color tint)
        {
            this.ItemSprite = itemSprite;
            this.ItemName = itemName;
            this.Tint = tint;
        }

        public Color Tint { get; set; }

        public string ItemName { get; }

        public Sprite ItemSprite { get; }
    }
}