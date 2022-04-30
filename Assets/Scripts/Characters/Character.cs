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
            if (intentions.TryConsumeJumpStart() && attachedController.isGrounded) {
                physics.velocity.y += config.jumpSpeed;
            }

            physics.velocity = Vector2.SmoothDamp(
                physics.velocity.SwizzleXZ(),
                config.maximumSpeed * intentions.intendedMovement,
                ref movementAcceleration,
                config.accelerationDuration
            ).SwizzleXZ().WithY(physics.velocity.y);

            physics.velocity += Physics.gravity * Time.deltaTime;

            attachedController.Move(physics.velocity * Time.deltaTime);

            if (attachedController.isGrounded) {
                physics.velocity.y = 0;
            }
        }
    }
}