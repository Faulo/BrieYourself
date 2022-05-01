using UnityEngine;

namespace BrieYourself.Characters {
    public class ArtificialInput : ComponentFeature<Character> {
        [SerializeField] float _hostileDetectionRadius;
        [SerializeField] LayerMask _whatIsHostile;
        [SerializeField] LayerMask _whatIsPrey;
        [SerializeField] Animator _attachedAnimator;

        public Transform closestHostile { get; private set; }

        public Character character => observedComponent;

        protected void FixedUpdate() {
            DetectHostiles();
        }

        void DetectHostiles() {
            var hits = Physics.SphereCastAll(transform.position, _hostileDetectionRadius,
                transform.forward, _hostileDetectionRadius, _whatIsHostile);

            foreach (var hit in hits) {
                if (!closestHostile) {
                    closestHostile = hit.transform;
                }
                float hitDistance = Mathf.Abs(Vector3.Distance(transform.position, hit.transform.position));
                float closestHostileDistance = Mathf.Abs(Vector3.Distance(transform.position, closestHostile.position));
                if (hitDistance < closestHostileDistance) {
                    closestHostile = hit.transform;
                }
                closestHostileDistance = Mathf.Abs(Vector3.Distance(transform.position, closestHostile.position));
                _attachedAnimator.SetFloat("closestHostileDistance", closestHostileDistance);
            }
        }

        void DetectPrey() {
            var hits = Physics.SphereCastAll(transform.position, _hostileDetectionRadius,
                transform.forward, _hostileDetectionRadius, _whatIsPrey);

            foreach (var hit in hits) {
                if (!closestHostile) {
                    closestHostile = hit.transform;
                }
                float hitDistance = Mathf.Abs(Vector3.Distance(transform.position, hit.transform.position));
                float closestHostileDistance = Mathf.Abs(Vector3.Distance(transform.position, closestHostile.position));
                if (hitDistance < closestHostileDistance) {
                    closestHostile = hit.transform;
                }
                closestHostileDistance = Mathf.Abs(Vector3.Distance(transform.position, closestHostile.position));
                _attachedAnimator.SetFloat("closestHostileDistance", closestHostileDistance);
            }
        }

        protected override void OnValidate() {
            if (!_attachedAnimator) {
                TryGetComponent(out _attachedAnimator);
            }
        }
    }
}
