using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Assertions;

namespace BrieYourself.Characters {
    public class Character : MonoBehaviour {
        [Header("MonoBehaviour configuration")]
        [SerializeField]
        CharacterController attachedController = default;
        [SerializeField]
        Animator attachedAnimator = default;

        [field: Header("Character configuration")]
        [field: SerializeField, Expandable]
        public CharacterConfig config { get; private set; }

        public Vector2 intendedVelocity {
            get => m_intendedVelocity;
            set {
                m_intendedVelocity = value;
                intendedSpeed = value.magnitude;
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


        public bool isGrounded {
            get => attachedAnimator.GetBool(nameof(isGrounded));
            private set => attachedAnimator.SetBool(nameof(isGrounded), value);
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

        [Header("Runtime fields")]
        [SerializeField]
        public Vector2 movementAcceleration = Vector2.zero;

        protected void OnValidate() {
            if (!attachedAnimator) {
                TryGetComponent(out attachedAnimator);
            }
            if (!attachedController) {
                TryGetComponent(out attachedController);
            }
        }
        protected void Start() {
            Assert.IsTrue(config);
        }
        protected void FixedUpdate() {
            attachedController.Move(velocity * Time.deltaTime);

            isGrounded = attachedController.isGrounded;

            if (attachedController.isGrounded) {
                verticalSpeed = Physics.gravity.y * Time.deltaTime;
            }
        }
        public void StartJumping() {
            verticalSpeed = config.jumpSpeed;
        }
        public void StopJumping() {
            verticalSpeed *= config.jumpAbortMultiplier;
        }
    }
}