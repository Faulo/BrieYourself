using UnityEngine;

namespace BrieYourself.Characters {
    [CreateAssetMenu]
    public class CharacterConfig : ScriptableAsset {
        [SerializeField, Range(0, 100)]
        public float maximumSpeed = 10;

        [Space]
        [SerializeField, Range(0, 10)]
        public float accelerationDuration = 1;
        [SerializeField, Range(0, 10)]
        public float rotationDuration = 1;

        [Space]
        [SerializeField, Range(0, 100)]
        public float jumpSpeed = 10;
        [SerializeField, Range(0, 1)]
        public float jumpAbortMultiplier = 0.25f;

        [Space]
        [SerializeField, Range(0, 100)]
        public float drag = 1;
    }
}