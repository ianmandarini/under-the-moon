using System;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class GroundChecker: MonoBehaviour
    {
        [SerializeField] private List<Transform> rayOrigins = default;
        [SerializeField] private LayerMask groundMask = default;
        [SerializeField] private float rayDistance = 0.1f;
        [SerializeField] private MovementSO movementSO = default;

        private void Update()
        {
            this.movementSO.IsGrounded = this.IsGrounded();
        }

        private bool IsGrounded()
        {
            foreach (Transform rayOrigin in this.rayOrigins)
            {
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, Vector2.down, this.rayDistance, this.groundMask);
                if (hit.collider != null)
                    return true;
            }
            return false;
        }
    }
}