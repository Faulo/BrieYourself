using UnityEngine;
using UnityEngine.Events;

namespace BrieYourself.Characters.StateMachines {
    public class StateMachineEvents : StateMachineBehaviour {
        [SerializeField]
        UnityEvent<GameObject> onStateEnter = new UnityEvent<GameObject>();
        [SerializeField]
        UnityEvent<GameObject> onStateUpdate = new UnityEvent<GameObject>();
        [SerializeField]
        UnityEvent<GameObject> onStateExit = new UnityEvent<GameObject>();

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            onStateEnter?.Invoke(animator.gameObject);
        }
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            onStateUpdate?.Invoke(animator.gameObject);
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            onStateExit?.Invoke(animator.gameObject);
        }
    }
}