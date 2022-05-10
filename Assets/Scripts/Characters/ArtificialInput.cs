using UnityEngine;
using Random = UnityEngine.Random;

namespace BrieYourself.Characters {
    public class ArtificialInput : ComponentFeature<Character> {
        [SerializeField] LayerMask _whatIsHostile;
        [SerializeField] float _hostileDetectionRadius;
        [SerializeField] LayerMask _whatIsPrey;
        [SerializeField] float _preyDetectionRadius;
        [SerializeField] Animator _attachedAnimator;
        [SerializeField] float strollRadius = 4f;


        public Transform closestHostile { get; private set; }
        public Transform closestPrey { get; private set; }
        public bool wantStroll;
        public Character character => observedComponent;

        protected void FixedUpdate() {
            DetectHostiles();
            DetectPrey();
            _attachedAnimator.SetBool("wantStroll", wantStroll);
        }

        void DetectHostiles() {
            closestHostile = null;
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
            }
            if (closestHostile) {
                float closestHostileDistance = Mathf.Abs(Vector3.Distance(transform.position, closestHostile.position));
                _attachedAnimator.SetFloat("closestHostileDistance", closestHostileDistance);
            } else {
                _attachedAnimator.SetFloat("closestHostileDistance", Mathf.Infinity);
            }
        }

        void DetectPrey() {
            closestPrey = null;
            var hits = Physics.SphereCastAll(transform.position, _preyDetectionRadius,
                transform.forward, _preyDetectionRadius, _whatIsPrey);

            foreach (var hit in hits) {
                if (!closestPrey) {
                    closestPrey = hit.transform;
                }
                float hitDistance = Mathf.Abs(Vector3.Distance(transform.position, hit.transform.position));
                float closestPreyDistance = Mathf.Abs(Vector3.Distance(character.attackPoint.position, closestPrey.position));
                if (hitDistance < closestPreyDistance) {
                    closestPrey = hit.transform;
                }

            }
            if (closestPrey) {
                float closestPreyDistance = Mathf.Abs(Vector3.Distance(transform.position, closestPrey.position));
                _attachedAnimator.SetFloat("closestPreyDistance", closestPreyDistance);
            } else {
                _attachedAnimator.SetFloat("closestPreyDistance", Mathf.Infinity);
            }
        }

        public Vector3 CalcStrollGoal() {
            var goal = new Vector3 {
                y = transform.position.y,
                x = transform.position.x + Random.Range(-strollRadius, strollRadius),
                z = transform.position.z + Random.Range(-strollRadius, strollRadius)
            };
            return goal;
        }

        protected override void OnValidate() {
            base.OnValidate();
            if (!_attachedAnimator) {
                TryGetComponent(out _attachedAnimator);
            }
        }
    }
}
