using UnityEngine;
using UnityEngine.Assertions;

namespace BrieYourself.Characters.StateMachines {
    public abstract class CharacterBehaviour : StateMachineBehaviour {
        protected Character character { get; private set; }
        protected CharacterConfig config { get; private set; }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            character = animator.GetComponent<Character>();
            Assert.IsTrue(character, $"Animator {animator} does not have a {typeof(Character)} component!");

            config = character.config;
        }
    }
}