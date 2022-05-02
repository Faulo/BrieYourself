using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Effects {
    [CreateAssetMenu]
    public class GameObjectEffect : ScriptableAsset {
        [SerializeField, Expandable]
        GameObject prefab = default;

        public void Play() {
            Instantiate(prefab);
        }
        public void Play(GameObject context) {
            Instantiate(prefab, context.transform.position, context.transform.rotation);
        }
    }
}