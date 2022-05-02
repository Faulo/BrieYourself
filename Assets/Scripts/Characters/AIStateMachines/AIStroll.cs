using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Characters.AIStateMachines {
    public class AIStroll : ArtificialBehaviour {
        Vector3 strollGoal;
        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            input.wantStroll = false;
            strollGoal = input.CalcStrollGoal();
            character.intendedVelocity = Vector2.zero;
        }

        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            var dir = (strollGoal - input.transform.position);
            if (dir.magnitude < 1f) {
                character.intendedVelocity = Vector2.zero;
                return;
            }
            dir.Normalize();
            character.intendedVelocity = dir.SwizzleXZ();
        }

        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.intendedVelocity = Vector2.zero;
        }
    }
}