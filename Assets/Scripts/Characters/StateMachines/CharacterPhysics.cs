using MyBox;
using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterPhysics : CharacterBehaviour {
        [SerializeField]
        bool applyDrag = true;
        [SerializeField, ConditionalField(nameof(applyDrag))]
        float dragMultiplier = 1;

        [Space]
        [SerializeField]
        bool applyGravity = true;
        [SerializeField, ConditionalField(nameof(applyGravity))]
        float gravityMultiplier = 1;

        [Space]
        [SerializeField]
        bool applyRotation = true;

        [Space]
        [SerializeField]
        bool applyMovement = true;
        [SerializeField, ConditionalField(nameof(applyMovement))]
        float movementSpeedMultiplier = 1;
        [SerializeField, ConditionalField(nameof(applyMovement))]
        float movementDurationMultiplier = 1;


        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (applyDrag) {
                ApplyDrag();
            }
            if (applyGravity) {
                ApplyGravity();
            }
            if (applyRotation) {
                ApplyRotation();
            }
            if (applyMovement) {
                ApplyMovement();
            }
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
        }

        void ApplyDrag() {
            character.velocity -= dragMultiplier * config.drag * Time.deltaTime * character.velocity.sqrMagnitude * character.velocity.normalized;
        }

        void ApplyGravity() {
            character.velocity += gravityMultiplier * Time.deltaTime * Physics.gravity;
        }

        void ApplyRotation() {
            character.horizontalRotation = Mathf.SmoothDampAngle(
                character.horizontalRotation,
                character.intendedRotation,
                ref character.rotationAcceleration,
                config.rotationDuration
            );
        }

        void ApplyMovement() {
            character.horizontalVelocity = Vector2.SmoothDamp(
                character.horizontalVelocity,
                movementSpeedMultiplier * config.maximumSpeed * character.intendedVelocity,
                ref character.movementAcceleration,
                movementDurationMultiplier * config.accelerationDuration
            );
        }
    }
}