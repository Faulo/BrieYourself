using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterSquishStop : CharacterBehaviour {

        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (character.TryGetComponent<Rigidbody>(out var rigidbody)) {
                rigidbody.velocity = Vector3.up * config.jumpSpeed;
            }
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.boxSize = Vector3.Lerp(config.squishBoxSize, config.defaultBoxSize, stateInfo.normalizedTime);
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (character.TryGetComponent<Rigidbody>(out var rigidbody)) {
                Destroy(rigidbody);
            }
            character.boxSize = config.defaultBoxSize;
            character.attachedController.enabled = true;
        }
    }
}
