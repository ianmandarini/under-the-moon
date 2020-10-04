using System;
using System.Collections;
using Extensions;
using Input;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Collider2D))]
    public class Item: MonoBehaviour
    {
        [SerializeField] private GameObject itemParent = default;
        [SerializeField] private Collider2D itemPhysicsCollider = default;
        [SerializeField] private string itemName = default;
        [SerializeField] private SpriteRenderer spriteRenderer = default;
        [SerializeField] private ItemSO itemSO = default;
        [SerializeField] private InputSO inputSO = default;
        [SerializeField] private Vector2 gravityVelocity = default;
        [SerializeField] private Rigidbody2D targetRigidBody2D = default;
        [SerializeField] private ParticleSystem consumeParticleSystem = default;
        [SerializeField] private GameObject interactionIndicator = default;
        private bool _isPlayerInside;
        private bool _isPickedUp;

        private void Update()
        {
            this.targetRigidBody2D.velocity = this.gravityVelocity;
            this.interactionIndicator.SetActive(this._isPlayerInside && !this._isPickedUp);
        }

        private void OnEnable()
        {
            this.inputSO.PickedOrDroppedItem += this.InputPickedOrDroppedItemEventHandler;
        }

        private void OnDisable()
        {
            this.inputSO.PickedOrDroppedItem -= this.InputPickedOrDroppedItemEventHandler;
        }
        
        private void InputPickedOrDroppedItemEventHandler(object sender, EventArgs e)
        {
            if(this._isPlayerInside && this.itemSO.CanPickOrDropItems && !this.itemSO.HasJustToggledItem)
                this.TogglePickDrop();
        }

        private void TogglePickDrop()
        {
            if (this._isPickedUp)
                this.Drop();
            else
                this.PickUp();
        }

        private void LateUpdate()
        {
            this.itemSO.HasJustToggledItem = false;
        }

        private void TurnOnPhysics()
        {
            this.itemPhysicsCollider.enabled = true;
            this.targetRigidBody2D.isKinematic = false;
            this.targetRigidBody2D.WakeUp();
        }
        
        private void TurnOffPhysics()
        {
            this.itemPhysicsCollider.enabled = false;
            this.targetRigidBody2D.isKinematic = true;
            this.targetRigidBody2D.Sleep();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.IsPlayer())
                this._isPlayerInside = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.IsPlayer())
                this._isPlayerInside = false;
        }
        

        private void PickUp()
        {
            if (this.itemSO.HasItemPickedUp)
                return;
            this._isPickedUp = true;
            this.itemSO.PickedItem(this.spriteRenderer.sprite, this.itemName, this.spriteRenderer.color);
            this.itemParent.transform.parent = this.itemSO.PickUpHandGameObject.transform;
            this.itemParent.transform.position = this.itemSO.PickUpHandGameObject.transform.position;
            this.TurnOffPhysics();;
        }

        private void Drop()
        {
            if (!this.itemSO.CanPickOrDropItems)
                return;
            this.itemSO.DroppedItem();
            this._isPickedUp = false;
            this.itemParent.transform.parent = null;
            this.TurnOnPhysics();
        }

        public void Consume()
        {
            this.Drop();
            this.StartCoroutine(this.PlayParticles());
            Destroy(this.transform.parent.gameObject);
        }

        private IEnumerator PlayParticles()
        {
            this.consumeParticleSystem.transform.parent = null;
            this.consumeParticleSystem.Play();
            yield return new WaitForSeconds(this.consumeParticleSystem.main.duration);
            Destroy(this.consumeParticleSystem.gameObject);
        }
    }
}