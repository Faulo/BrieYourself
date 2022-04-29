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
        public CharacterIntentions intentions = new CharacterIntentions();
        [SerializeField]
        public CharacterPhysics physics = new CharacterPhysics();

        Vector2 movementAcceleration = Vector2.zero;

        protected void Start() {

        }
        protected void FixedUpdate() {
            physics.velocity = Vector2.SmoothDamp(
                physics.velocity.SwizzleXZ(),
                config.maximumSpeed * intentions.intendeMovement,
                ref movementAcceleration,
                config.accelerationDuration
            ).SwizzleXZ().WithY(physics.velocity.y);

            physics.velocity += Time.deltaTime * Physics.gravity;

            attachedController.Move(physics.velocity);

            if (attachedController.isGrounded) {
                physics.velocity.y = 0;
            }
        }
    }
}