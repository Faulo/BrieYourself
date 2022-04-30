using UnityEngine;
using UnityEngine.InputSystem;

namespace BrieYourself.Characters {
    public class HumanInput : ComponentFeature<Character>, PlayerActions.IAvatarActions {
        PlayerActions inputActions;
        CharacterIntentions intentions;

        protected void OnEnable() {
            intentions = observedComponent.intentions;
            inputActions = new PlayerActions();
            inputActions.Avatar.SetCallbacks(this);
            inputActions.Enable();
        }

        protected void OnDisable() {
            if (inputActions != null) {
                inputActions.Disable();
                inputActions.Dispose();
                inputActions = null;
            }
        }

        public void OnMove(InputAction.CallbackContext context) {
            intentions.intendedMovement = context.ReadValue<Vector2>();
        }
        public void OnJump(InputAction.CallbackContext context) {
            intentions.intendsJump = context.performed;
        }
        public void OnInteract(InputAction.CallbackContext context) {
            intentions.intendsInteract = context.performed;
        }
        public void OnStickLook(InputAction.CallbackContext context) {
            intentions.intendedLook = context.ReadValue<Vector2>();
        }
        public void OnMouseLook(InputAction.CallbackContext context) {
        }
    }
}