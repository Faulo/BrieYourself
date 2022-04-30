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
        }

        protected void OnDisable() {
            if (cameraInstance) {
                Destroy(cameraInstance.gameObject);
            }
        }
    }
}