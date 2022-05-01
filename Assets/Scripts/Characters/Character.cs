using MyBox;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace BrieYourself.Characters {
    public class Character : MonoBehaviour {
        [Header("MonoBehaviour configuration")]
        [SerializeField]
        public CharacterController attachedController = default;
        [SerializeField]
        Animator attachedAnimator = default;
        [SerializeField]
        BoxCollider attachedBox = default;

        [field: Header("Character configuration")]
        [field: SerializeField, Expandable]
        public CharacterConfig config { get; private set; }

        public Vector2 intendedVelocity {
            get {
                var velocity = m_intendedVelocity;
                onProcessInput?.Invoke(ref velocity);
                return velocity;
            }
            set {
                m_intendedVelocity = value;
                intendedSpeed = value.magnitude;
                if (value != Vector2.zero) {
                    intendedRotation = Quaternion.LookRotation(intendedVelocity.SwizzleXZ()).eulerAngles.y;
                }
            }
        }
        Vector2 m_intendedVelocity;
        public float intendedSpeed {
            get => attachedAnimator.GetFloat(nameof(intendedSpeed));
            private set => attachedAnimator.SetFloat(nameof(intendedSpeed), value);
        }
        public bool intendsJump {
            get => attachedAnimator.GetBool(nameof(intendsJump));
            set {
                if (!intendsJump && value) {
                    intendsJumpStart = true;
                }
                attachedAnimator.SetBool(nameof(intendsJump), value);
            }
        }
        public bool intendsJumpStart {
            get => attachedAnimator.GetBool(nameof(intendsJumpStart));
            set => attachedAnimator.SetBool(nameof(intendsJumpStart), value);
        }
        public bool intendsInteract {
            get => attachedAnimator.GetBool(nameof(intendsInteract));
            set {
                if (!intendsInteract && value) {
                    intendsInteractStart = true;
                }
                attachedAnimator.SetBool(nameof(intendsInteract), value);
            }
        }
        public bool intendsInteractStart {
            get => attachedAnimator.GetBool(nameof(intendsInteractStart));
            set => attachedAnimator.SetBool(nameof(intendsInteractStart), value);
        }

        public bool isGrounded {
            get => attachedAnimator.GetBool(nameof(isGrounded));
            private set {
                bool wasGrounded = isGrounded;
                if (wasGrounded != value) {
                    if (wasGrounded) {
                        onBecomeAirborne.Invoke(gameObject);
                    }
                    attachedAnimator.SetBool(nameof(isGrounded), value);
                    if (value) {
                        onBecomeGrounded.Invoke(gameObject);
                    }
                }
            }
        }

        public Vector2 horizontalVelocity {
            get => m_horizontalVelocity;
            set {
                m_horizontalVelocity = value;
                horizontalSpeed = value.magnitude;
            }
        }
        Vector2 m_horizontalVelocity;

        public float horizontalSpeed {
            get => attachedAnimator.GetFloat(nameof(horizontalSpeed));
            private set => attachedAnimator.SetFloat(nameof(horizontalSpeed), value);
        }

        public float verticalSpeed {
            get => attachedAnimator.GetFloat(nameof(verticalSpeed));
            set => attachedAnimator.SetFloat(nameof(verticalSpeed), value);
        }

        public Vector3 velocity {
            get => horizontalVelocity.SwizzleXZ().WithY(verticalSpeed);
            set {
                horizontalVelocity = value.SwizzleXZ();
                verticalSpeed = value.y;
            }
        }

        public float horizontalRotation {
            get => transform.eulerAngles.y;
            set => transform.eulerAngles = transform.eulerAngles.WithY(value);
        }

        public float intendedRotation {
            get => attachedAnimator.GetFloat(nameof(intendedRotation));
            private set => attachedAnimator.SetFloat(nameof(intendedRotation), value);
        }

        [Header("Events")]
        [SerializeField]
        UnityEvent<GameObject> onBecomeGrounded = new UnityEvent<GameObject>();
        [SerializeField]
        UnityEvent<GameObject> onBecomeAirborne = new UnityEvent<GameObject>();
        [SerializeField]
        UnityEvent<GameObject> onStep = new UnityEvent<GameObject>();
        [SerializeField]
        UnityEvent<GameObject> onHurt = new UnityEvent<GameObject>();

        [Header("Runtime fields")]
        [SerializeField, ReadOnly]
        public Vector2 movementAcceleration = Vector2.zero;
        [SerializeField, ReadOnly]
        public float rotationAcceleration = 0;
        [SerializeField, ReadOnly]
        public Vector2 intendedLook = Vector2.zero;

        bool canBeHurt => attachedController.enabled;

        public Vector3 boxSize {
            get => attachedBox.size;
            set {
                attachedBox.size = value;
                attachedBox.center = new Vector3(0, (value.y / 2) + config.feetHeight, 0);
            }
        }

        public event InputProcessor onProcessInput;

        public delegate void InputProcessor(ref Vector2 velocity);

        protected void OnValidate() {
            if (!attachedAnimator) {
                transform.TryGetComponentInChildren(out attachedAnimator);
            }
            if (!attachedController) {
                TryGetComponent(out attachedController);
            }
            if (!attachedBox) {
                TryGetComponent(out attachedBox);
            }
        }
        protected void Update() {
            Assert.IsTrue(config);
            boxSize = config.defaultBoxSize;
            attachedController.radius = config.capsuleRadius;
            attachedController.height = config.capsuleHeight;
            attachedController.center = Vector3.up * config.capsuleOffset;
        }
        float stepTimer;
        protected void FixedUpdate() {
            if (attachedController.enabled) {
                attachedController.Move(velocity * Time.deltaTime);

                isGrounded = attachedController.isGrounded;

                if (attachedController.isGrounded) {
                    verticalSpeed = Physics.gravity.y * Time.deltaTime;

                    if (horizontalSpeed > 1) {
                        stepTimer += Time.deltaTime;
                        if (stepTimer > config.stepDuration) {
                            stepTimer = 0;
                            onStep.Invoke(gameObject);
                        }
                    }
                }
            }
        }

        public void TakeDamage() {
            if (!canBeHurt) {
                return;
            }
            attachedAnimator.SetTrigger(nameof(onHurt));
            onHurt.Invoke(gameObject);
        }
    }
}