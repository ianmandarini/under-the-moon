using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class ItemPickedGUI: MonoBehaviour
    {
        [SerializeField] private Canvas itemPickedCanvas = default;
        [SerializeField] private ItemSO itemSO = default;
        [SerializeField] private Image itemImageGUI = default;
        [SerializeField] private TMP_Text itemTextGUI = default;

        private void Start()
        {
            this.itemPickedCanvas.enabled = false;
        }

        private void OnEnable()
        {
            this.itemSO.ItemPickedUp += this.ItemPickedUpEventHandler;
            this.itemSO.ItemDropped += this.ItemDroppedEventHandler;
        }

        private void OnDisable()
        {
            this.itemSO.ItemPickedUp -= this.ItemPickedUpEventHandler;
            this.itemSO.ItemDropped -= this.ItemDroppedEventHandler;
        }

        private void ItemDroppedEventHandler(object sender, EventArgs e)
        {
            this.itemPickedCanvas.enabled = false;
        }

        private void ItemPickedUpEventHandler(object sender, ItemPickedEventArgs e)
        {
            this.itemPickedCanvas.enabled = true;
            this.itemImageGUI.sprite = e.ItemSprite;
            this.itemTextGUI.text = e.ItemName;
            this.itemImageGUI.color = e.Tint;
        }
    }
}