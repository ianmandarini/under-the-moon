using System;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Custom/ItemSO")]
    public sealed class ItemSO: ScriptableObject
    {
        public bool CanPickOrDropItems { get; private set; }

        public void AllowPickOrDropItems() => this.CanPickOrDropItems = true;
        public void BlockPickOrDropItems() => this.CanPickOrDropItems = false;

        public bool HasJustToggledItem = false;
        
        public GameObject PickUpHandGameObject { get; private set; }

        public void Start()
        {
            this.HasItemPickedUp = false;
            this.HasJustToggledItem = false;
        }

        public void SetPickUpHand(GameObject gameObject)
        {
            this.PickUpHandGameObject = gameObject;
        }

        public bool HasItemPickedUp { get; private set; }

        public event EventHandler<ItemPickedEventArgs> ItemPickedUp;
        public event EventHandler ItemDropped;
        
        public void PickedItem(Sprite spriteRendererSprite, string itemName, Color tint)
        {
            this.HasJustToggledItem = true;
            this.HasItemPickedUp = true;
            this.OnItemPickedUp(new ItemPickedEventArgs(spriteRendererSprite, itemName, tint));
        }

        public void DroppedItem()
        {
            this.HasJustToggledItem = true;
            this.HasItemPickedUp = false;
            this.OnItemDropped();
        }

        private void OnItemDropped()
        {
            this.ItemDropped?.Invoke(this, EventArgs.Empty);
        }

        private void OnItemPickedUp(ItemPickedEventArgs e)
        {
            this.ItemPickedUp?.Invoke(this, e);
        }
    }
}