using System;
using Items;
using UnityEngine;
using UnityEngine.Events;

namespace Locks
{
    [RequireComponent(typeof(Collider2D))]
    public class Lock : MonoBehaviour
    {
        [SerializeField] bool shouldConsumeKey = true;
        [SerializeField] private GameObject key = default;
        [SerializeField] UnityEvent unlocked = default;

        private bool _isUnlocked = false;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Item item = other.GetComponent<Item>();
            if (item == null)
                return;
            if(item != null && other.transform.parent.gameObject == this.key && !this._isUnlocked)
                this.Unlock(item);
        }

        private void Unlock(Item item)
        {
            this._isUnlocked = true;
            if (this.shouldConsumeKey)
                item.Consume();
            this.unlocked.Invoke();
        }
    }
}
