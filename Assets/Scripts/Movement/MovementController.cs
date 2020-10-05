using System;
using System.Collections;
using Extensions;
using Input;
using UnityEngine;

namespace Movement
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private InputSO inputSO = default;
        [SerializeField] private MovementSO movementSO = default;
    
        [SerializeField] private float walkingSpeed = default;
        [SerializeField] private float runningSpeed = default;
        [SerializeField] private float jumpIntensity = default;
        [SerializeField] private float jumpCooldown = 1.0f;
    
        [SerializeField] private Vector2 gravityVelocity = default;
    
        [SerializeField] private Rigidbody2D target = default;

        private Vector2 _velocity;
        private float _lastHorizontalAxis = 0.0f;
        private bool _isJumpOnCooldown = false;

        private void OnEnable()
        {
            this.inputSO.Jumped += this.JumpedEventHandler;
        }

        private void OnDisable()
        {
            this.inputSO.Jumped -= this.JumpedEventHandler;
        }

        private void JumpedEventHandler(object sender, EventArgs e)
        {
            if (!this.movementSO.IsGrounded)
                return;
            if (this._isJumpOnCooldown)
                return;
            this._isJumpOnCooldown = true;
            this.StartCoroutine(this.UndoJumpCooldown());
            this.target.AddForce(Vector2.up * this.jumpIntensity, ForceMode2D.Impulse);
        }

        private IEnumerator UndoJumpCooldown()
        {
            yield return new WaitForSeconds(this.jumpCooldown);
            this._isJumpOnCooldown = false;
        }

        private void FixedUpdate()
        {
            this.ProcessInput();
            this.Move();
        }

        private void ProcessInput()
        {
            this._velocity = this.movementSO.CanMove ? this.VelocityFromInput() : Vector2.zero;
        }

        private Vector2 VelocityFromInput()
        {
            float horizontalSpeed = this.inputSO.HorizontalAxis;
            horizontalSpeed *= this.inputSO.IsRunning ? this.runningSpeed : this.walkingSpeed;
            return new Vector2(horizontalSpeed, 0.0f);
        }

        private void Move()
        {
            this.target.AddForce(this.gravityVelocity, ForceMode2D.Force);

            Vector2 velocity = this.target.velocity;
            velocity.x = this._velocity.x;
            this.target.velocity = velocity;
            
            PlayerAnimationStateEventArgs stateEventArgs = new PlayerAnimationStateEventArgs(this._lastHorizontalAxis, 
                this.inputSO.HorizontalAxis);
            this.movementSO.OnMovementStateUpdated(stateEventArgs);

            if(this.inputSO.HorizontalAxis.Magnitude() > 0.01f)
                this._lastHorizontalAxis = this.inputSO.HorizontalAxis;
        }
    }
}
