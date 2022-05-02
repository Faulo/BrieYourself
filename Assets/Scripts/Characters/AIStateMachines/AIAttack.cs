using UnityEngine;

namespace BrieYourself.Characters.AIStateMachines {
    public class AIAttack : ArtificialBehaviour {
        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.intendsInteract = true;
            character.intendedVelocity = Vector2.zero;
        }

        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {

        }

        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.intendsInteract = false;
        }
    }
}