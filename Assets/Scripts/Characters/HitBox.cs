using UnityEngine;

namespace BrieYourself.Characters {
    public class HitBox : MonoBehaviour {
        [SerializeField]
        Character owner = default;
        protected void InitializeAttack(Character owner) {
            this.owner = owner;
        }
        protected void OnTriggerEnter(Collider other) {
            if (other.TryGetComponent<Character>(out var character) && character != owner) {
                character.TakeDamage();
            }
        }
    }
}
