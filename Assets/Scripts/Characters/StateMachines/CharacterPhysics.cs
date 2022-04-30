using MyBox;
using UnityEngine;
using UnityEngine.Assertions;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterPhysics : StateMachineBehaviour {
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
        bool applyMovement = true;
        [SerializeField, ConditionalField(nameof(applyMovement))]
        float movementMultiplier = 1;

        Character character;
        CharacterConfig config => character.config;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.TryGetComponent(out character);
            Assert.IsTrue(character, $"Animator {animator} does not have a {typeof(Character)} component!");
        }
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if (applyDrag) {
                ApplyDrag();
            }
            if (applyGravity) {
                ApplyGravity();
            }
            if (applyMovement) {
                ApplyMovement();
            }
        }

        void ApplyDrag() {
            character.velocity -= dragMultiplier * config.drag * Time.deltaTime * character.velocity.sqrMagnitude * character.velocity.normalized;
        }
        void ApplyGravity() {
            character.velocity += gravityMultiplier * Time.deltaTime * Physics.gravity;
        }
        void ApplyMovement() {
            character.horizontalVelocity = Vector2.SmoothDamp(
                character.horizontalVelocity,
                movementMultiplier * config.maximumSpeed * character.intendedVelocity,
                ref character.movementAcceleration,
                config.accelerationDuration
            );
        }
    }
}