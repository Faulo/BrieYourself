using UnityEngine;
using UnityEngine.Events;

namespace BrieYourself.Characters {
    public class MaskPickup : MonoBehaviour {
        [SerializeField]
        GameObject mask = default;
        [SerializeField]
        CharacterConfig config = default;
        [SerializeField]
        UnityEvent<GameObject> onPickUp = new();

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
