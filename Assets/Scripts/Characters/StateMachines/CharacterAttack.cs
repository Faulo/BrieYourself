using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterAttack : CharacterBehaviour {
        [SerializeField]
        GameObject attackPrefab = default;
        [SerializeField, Range(0, 1)]
        float attackTime = 0.5f;

        GameObject attackInstance;

        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.intendsInteractStart = false;
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (!attackInstance && stateInfo.normalizedTime >= attackTime) {
                attackInstance = Instantiate(attackPrefab, character.transform);
                attackInstance.BroadcastMessage("InitializeAttack", character, SendMessageOptions.DontRequireReceiver);
            }
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (attackInstance) {
                Destroy(attackInstance);
                attackInstance = null;
            }
        }
    }
}