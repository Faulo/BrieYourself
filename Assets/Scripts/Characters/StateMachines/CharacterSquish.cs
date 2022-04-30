using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterSquish : CharacterBehaviour {
        [SerializeField]
        Vector3 scale = Vector3.one;

        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.transform.localScale = scale;
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.transform.localScale = Vector3.one;
        }
    }
}
