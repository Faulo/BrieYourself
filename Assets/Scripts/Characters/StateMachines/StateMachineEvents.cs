using UnityEngine;
using UnityEngine.Events;

namespace BrieYourself.Characters.StateMachines {
    public class StateMachineEvents : CharacterBehaviour {
        [SerializeField]
        UnityEvent<GameObject> onStateEnter = new();
        [SerializeField]
        UnityEvent<GameObject> onStateUpdate = new();
        [SerializeField]
        UnityEvent<GameObject> onStateExit = new();

        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            onStateEnter?.Invoke(animator.gameObject);
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            onStateUpdate?.Invoke(animator.gameObject);
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            onStateExit?.Invoke(animator.gameObject);
        }
    }
}