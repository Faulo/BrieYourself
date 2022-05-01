using UnityEngine;

namespace BrieYourself {
    public class DeleteVFX : MonoBehaviour {
        [SerializeField]
        GameObject objectToDelete = default;
        [SerializeField, Range(0, 20)]
        float seconds = 2;

        protected void Start() {
            Destroy(objectToDelete, seconds);
        }
    }
}
