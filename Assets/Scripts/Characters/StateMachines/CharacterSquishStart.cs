using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterSquishStart : CharacterBehaviour {
        [SerializeField]
        float speed = 1;
        [SerializeField]
        float drag = 1;

        Rigidbody rigidbody;

        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.attachedController.enabled = false;

            rigidbody = character.gameObject.AddComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            rigidbody.freezeRotation = true;
            rigidbody.drag = drag;
            rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.boxSize = Vector3.Lerp(config.defaultBoxSize, config.squishBoxSize, stateInfo.normalizedTime);
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.boxSize = config.squishBoxSize;

            rigidbody.isKinematic = false;
            rigidbody.velocity = speed * character.intendedVelocity.SwizzleXZ();
        }
    }
}
