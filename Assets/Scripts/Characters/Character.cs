using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Characters {
    public class Character : MonoBehaviour {
        [Header("MonoBehaviour configuration")]
        [SerializeField]
        CharacterController attachedController = default;

        [Header("Character configuration")]
        [SerializeField, Expandable]
        CharacterConfig config = default;

        [Header("Runtime fields")]
        [SerializeField]
        public CharacterIntentions intentions = new();
        [SerializeField]
        public CharacterPhysics physics = new();

        Vector2 movementAcceleration = Vector2.zero;

        protected void Start() {

        }
        protected void FixedUpdate() {
            ApplyDrag();
            ApplyGravity();
            ApplyJump();
            ApplyMovement();

            attachedController.Move(physics.velocity * Time.deltaTime);

            if (attachedController.isGrounded) {
                physics.velocity.y = 0;
            }
        }
        void ApplyJump() {
            if (intentions.TryConsumeJumpStart() && attachedController.isGrounded) {
                physics.velocity.y += config.jumpSpeed;
            }
        }
        void ApplyGravity() {
            physics.velocity += Physics.gravity * Time.deltaTime;
        }
        void ApplyMovement() {
            physics.velocity = Vector2.SmoothDamp(
                physics.velocity.SwizzleXZ(),
                config.maximumSpeed * intentions.intendedMovement,
                ref movementAcceleration,
                config.accelerationDuration
            ).SwizzleXZ().WithY(physics.velocity.y);
        }
        void ApplyDrag() {
            physics.velocity -= config.drag * Time.deltaTime * physics.velocity.sqrMagnitude * physics.velocity.normalized;
        }
    }
}