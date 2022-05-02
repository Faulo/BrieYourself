using UnityEngine;
using UnityEngine.Assertions;

namespace BrieYourself.Characters.StateMachines {
    public abstract class CharacterBehaviour : StateMachineBehaviour {
        protected Animator animator { get; private set; }
        protected Character character { get; private set; }
        protected CharacterConfig config { get; private set; }

        public sealed override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            this.animator = animator;
            character = animator.GetComponentInParent<Character>();
            Assert.IsTrue(character, $"Animator {animator} does not have a {typeof(Character)} component!");

            config = character.config;
            StateEnter(stateInfo, layerIndex);
        }
        protected abstract void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex);

        public sealed override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if (animator.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash == stateInfo.fullPathHash) {
                StateUpdate(stateInfo, layerIndex);
            }
        }
        protected abstract void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex);

        public sealed override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            StateExit(stateInfo, layerIndex);
        }
        protected abstract void StateExit(in AnimatorStateInfo stateInfo, int layerIndex);
    }
}