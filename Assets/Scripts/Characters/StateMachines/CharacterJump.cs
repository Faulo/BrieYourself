using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterJump : CharacterBehaviour {
        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.verticalSpeed = config.jumpSpeed;
            character.intendsJumpStart = false;
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (character.verticalSpeed > 0) {
                character.verticalSpeed *= config.jumpAbortMultiplier;
            }
        }
    }
}