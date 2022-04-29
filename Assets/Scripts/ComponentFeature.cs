using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself {
    public abstract class ComponentFeature<TComponent> : MonoBehaviour where TComponent : Component {
        [SerializeField, Expandable]
        protected TComponent observedComponent = default;
        protected virtual void Awake() {
            SetUpComponents();
        }
        protected virtual void OnValidate() {
            SetUpComponents();
        }
        protected virtual void SetUpComponents() {
            _ = observedComponent
                || transform.TryGetComponentInParent(out observedComponent)
                || transform.TryGetComponentInChildren(out observedComponent);
        }
    }
}