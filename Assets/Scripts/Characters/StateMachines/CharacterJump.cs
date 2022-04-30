using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterJump : CharacterBehaviour {

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            character.verticalSpeed = config.jumpSpeed;
            character.intendsJumpStart = false;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if (character.verticalSpeed > 0) {
                character.verticalSpeed *= config.jumpAbortMultiplier;
            }
        }
    }
}