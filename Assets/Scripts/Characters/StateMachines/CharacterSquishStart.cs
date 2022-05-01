using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterSquishStart : CharacterBehaviour {
        [SerializeField]
        float velocityMultiplier = 1;
        [SerializeField]
        float drag = 1;
        [SerializeField]
        float transformDuration = 1;

        Rigidbody rigidbody;
        float speed;
        float timer;

        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            speed = character.velocity.magnitude;
            character.attachedController.enabled = false;

            rigidbody = character.gameObject.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.freezeRotation = true;
            rigidbody.drag = drag;
            rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

            timer = 0;
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            timer += Time.deltaTime;
            character.boxSize = Vector3.Lerp(config.defaultBoxSize, config.squishBoxSize, timer / transformDuration);
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.boxSize = config.squishBoxSize;

            rigidbody.useGravity = true;
            rigidbody.velocity = velocityMultiplier * speed * character.intendedVelocity.SwizzleXZ();
        }
    }
}
