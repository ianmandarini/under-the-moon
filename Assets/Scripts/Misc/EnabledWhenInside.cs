using System;
using Extensions;
using UnityEngine;

namespace Misc
{
    [RequireComponent(typeof(Collider2D))]
    public class EnabledWhenInside: MonoBehaviour
    {
        [SerializeField] private GameObject target = default;

        private void OnEnable()
        {
            this.target.SetActive(false);
        }
        
        private void OnDisable()
        {
            this.target.SetActive(false);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!this.isActiveAndEnabled)
            {
                this.target.SetActive(false);
                return;
            }
            if(other.IsPlayer())
                this.target.SetActive(true);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!this.isActiveAndEnabled)
            {
                this.target.SetActive(false);
                return;
            }
            if(other.IsPlayer())
                this.target.SetActive(false);
        }
    }
}