using UnityEngine;
using UnityEngine.InputSystem;

namespace BrieYourself.Characters {
    public class HumanInput : ComponentFeature<Character>, PlayerActions.IAvatarActions {
        PlayerActions inputActions;

        protected void OnEnable() {
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
            observedComponent.intendedVelocity = context.ReadValue<Vector2>();
        }
        public void OnJump(InputAction.CallbackContext context) {
            observedComponent.intendsJump = context.performed;
        }
        public void OnInteract(InputAction.CallbackContext context) {
            observedComponent.intendsInteract = context.performed;
        }
        public void OnStickLook(InputAction.CallbackContext context) {
            observedComponent.intendedLook = context.ReadValue<Vector2>();
        }
        public void OnMouseLook(InputAction.CallbackContext context) {
        }
    }
}