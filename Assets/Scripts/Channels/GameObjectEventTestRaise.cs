using UnityEngine;

namespace BrieYourself.Channels {
    public class GameObjectEventTestRaise : MonoBehaviour {
        [SerializeField] GameObjectEventChannel _gameObjectEventChannel;

        [ContextMenu("Test")]
        void RaiseEvent() {
            _gameObjectEventChannel.Raise(this.gameObject);
        }
    }
}