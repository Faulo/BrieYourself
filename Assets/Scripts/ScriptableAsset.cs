using MyBox;
using UnityEngine;

namespace BrieYourself {
    public class ScriptableAsset : ScriptableObject {
        [SerializeField, ReadOnly]
        ScriptableAsset asset = default;
        protected virtual void OnValidate() {
            if (asset != this) {
                asset = this;
            }
        }
    }
}