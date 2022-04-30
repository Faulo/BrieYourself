using System;
using UnityEngine;

namespace BrieYourself.Characters {
    [Serializable]
    public class CharacterIntentions {
        [SerializeField]
        public Vector2 intendedMovement = Vector2.zero;
        [SerializeField]
        public Vector2 intendedLook = Vector2.zero;

        public bool intendsJump {
            get => m_intendsJump;
            set {
                if (!m_intendsJump && value) {
                    intendsJumpStart = true;
                }
                m_intendsJump = value;
            }
        }
        [SerializeField]
        bool m_intendsJump = false;

        bool intendsJumpStart;
        public bool TryConsumeJumpStart() {
            if (intendsJumpStart) {
                intendsJumpStart = false;
                return true;
            }
            return false;
        }

        public bool intendsInteract {
            get => m_intendsJump;
            set {
                if (!m_intendsInteract && value) {
                    intendsInteractStart = true;
                }
                m_intendsInteract = value;
            }
        }
        [SerializeField]
        bool m_intendsInteract = false;
        [SerializeField]
        bool intendsInteractStart = false;
        public bool TryConsumeInteractStart() {
            if (intendsInteractStart) {
                intendsInteractStart = false;
                return true;
            }
            return false;
        }
    }
}