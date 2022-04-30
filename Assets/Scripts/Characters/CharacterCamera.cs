using Cinemachine;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Characters {
    public class CharacterCamera : ComponentFeature<Character> {
        [SerializeField, Expandable]
        CinemachineVirtualCamera cameraPrefab = default;

        CinemachineVirtualCamera cameraInstance;

        protected void OnEnable() {
            cameraInstance = Instantiate(cameraPrefab);
            cameraInstance.LookAt = observedComponent.transform;
            cameraInstance.Follow = observedComponent.transform;

            observedComponent.onProcessInput += TranslateInput;
        }

        protected void OnDisable() {
            observedComponent.onProcessInput -= TranslateInput;

            if (cameraInstance) {
                Destroy(cameraInstance.gameObject);
            }
        }

        public void TranslateInput(ref Vector2 input) {
            var forward = cameraInstance.transform.forward * input.y;
            var right = cameraInstance.transform.right * input.x;
            input = (forward + right).SwizzleXZ();
        }
    }
}