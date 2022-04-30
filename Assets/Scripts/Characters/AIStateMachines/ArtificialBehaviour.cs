using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Assertions;

namespace BrieYourself.Characters.AIStateMachines {
    public abstract class ArtificialBehaviour : StateMachineBehaviour {
        protected ArtificialInput input { get; private set; }
        protected Animator animator { get; private set; }
        
        protected Character character { get; private set; }
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex) {
            this.animator = animator;
            input = animator.GetComponent<ArtificialInput>();
            character = input.character;
            Assert.IsTrue(input, $"Animator {animator} does not have a {typeof(ArtificialInput)} component!");
            
            StateEnter(stateInfo, layerIndex);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex) {
            StateUpdate(stateInfo, layerIndex);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex) {
            StateExit(stateInfo, layerIndex);
        }

        protected abstract void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex);
        protected abstract void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex);
        protected abstract void StateExit(in AnimatorStateInfo stateInfo, int layerIndex);

    }
}