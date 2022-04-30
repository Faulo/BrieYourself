using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterSquish : CharacterBehaviour {
        [SerializeField]
        Vector3 scale = Vector3.one;
        [SerializeField]
        float velocityMultiplier = 1;
        [SerializeField]
        float drag = 1;

        Rigidbody rigidbody;

        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.transform.localScale = scale;
            character.attachedController.enabled = false;
            rigidbody = character.gameObject.AddComponent<Rigidbody>();
            rigidbody.velocity = velocityMultiplier * character.velocity;
            rigidbody.freezeRotation = true;
            rigidbody.drag = drag;
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            character.transform.localScale = Vector3.one;
            character.attachedController.enabled = true;
            Destroy(rigidbody);
        }
    }
}
