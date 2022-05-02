using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterSquishStop : CharacterBehaviour {
        [SerializeField, Range(0, 100)]
        float jumpSpeed = 10;

        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (character.TryGetComponent<Rigidbody>(out var rigidbody)) {
                rigidbody.velocity = rigidbody.velocity.WithY(jumpSpeed);
            }
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.boxSize = Vector3.Lerp(config.squishBoxSize, config.defaultBoxSize, stateInfo.normalizedTime);
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (character.TryGetComponent<Rigidbody>(out var rigidbody)) {
                character.velocity = rigidbody.velocity;
                Destroy(rigidbody);
            }
            character.boxSize = config.defaultBoxSize;
            character.attachedController.enabled = true;
        }
    }
}
