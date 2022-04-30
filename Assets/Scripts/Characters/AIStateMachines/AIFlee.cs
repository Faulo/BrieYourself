using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Characters.AIStateMachines {
    public class AIFlee : ArtificialBehaviour {
        [SerializeField] float _fleeSpeed = 2f;
        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {

        }

        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            var dir = (input.transform.position - input.closestHostile.position).normalized;
            character.intendedVelocity = dir.SwizzleXZ();
        }

        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.intendedVelocity = Vector2.zero;
        }
    }
}