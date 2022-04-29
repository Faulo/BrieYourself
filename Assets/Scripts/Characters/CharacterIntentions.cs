using System;
using UnityEngine;

namespace BrieYourself.Characters {
    [Serializable]
    public class CharacterIntentions {
        [SerializeField]
        public Vector2 intendeMovement = Vector2.zero;
        [SerializeField]
        public Vector2 intendedLook = Vector2.zero;

        [SerializeField]
        public bool intendsJump = false;
        [SerializeField]
        public bool intendsJumpStart = false;
        public bool TryConsumeJumpStart() {
            if (intendsJumpStart) {
                intendsJumpStart = false;
                return true;
            }
            return false;
        }
    }
}