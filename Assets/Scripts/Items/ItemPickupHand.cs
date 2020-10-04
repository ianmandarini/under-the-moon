using System;
using UnityEngine;

namespace Items
{
    public class ItemPickupHand: MonoBehaviour
    {
        [SerializeField] private ItemSO itemSO = default;
        
        private void Start()
        {
            this.itemSO.SetPickUpHand(this.gameObject);
        }
    }
}