using BrieYourself.Characters;
using UnityEngine;

namespace BrieYourself.Effects {
    [CreateAssetMenu]
    public class CharacterEffect : ScriptableAsset {
        public void StartJumping(GameObject obj) {
            obj.GetComponent<Character>().StartJumping();
        }
        public void StopJumping(GameObject obj) {
            obj.GetComponent<Character>().StopJumping();
        }
    }
}