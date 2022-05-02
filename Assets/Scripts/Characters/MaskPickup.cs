using BrieYourself.Characters;
using UnityEngine;
using UnityEngine.Events;

namespace BrieYourself {
    public class MaskPickup : MonoBehaviour {
        [SerializeField]
        GameObject mask = default;
        [SerializeField]
        CharacterConfig config = default;
        [SerializeField]
        UnityEvent<GameObject> onPickUp = new UnityEvent<GameObject>();

        protected void Update() {
            transform.Rotate(0, 0.1f, 0);
        }

        protected void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player") && other.TryGetComponent<Character>(out var character)) {
                character.AttachToHead(mask);
                character.SetConfig(config);
                onPickUp.Invoke(mask);
                Destroy(gameObject);
            }
        }
    }
}
