using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Characters.AIStateMachines {
    public class AIChase : ArtificialBehaviour{
        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            
        }

        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (!input.closestPrey) {
                return;
            }
            var dir = (input.closestPrey.transform.position - input.transform.position).normalized;
            character.intendedVelocity = dir.SwizzleXZ();
        }

        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.intendedVelocity = Vector2.zero;
        }
    }
}