using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Characters.AIStateMachines {
    public class AIIdle : ArtificialBehaviour {
 
        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
         
        }

        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            var rand = Random.Range(0f, 1f);
            if (rand > 0.997) {
                input.wantStroll = true;
            }
        }

        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
    
        }
    }
}