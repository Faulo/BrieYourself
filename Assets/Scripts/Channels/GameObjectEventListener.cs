using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Events;

namespace BrieYourself.Channels {
    public class GameObjectEventListener : MonoBehaviour {
        [SerializeField, Expandable()] 
        GameObjectEventChannel _gameObjectEventChannel;
        [SerializeField]
        UnityEvent<GameObject> _response;

        protected void OnEnable() {
            _gameObjectEventChannel.eventRaised += Respond;
        }

        protected void OnDisable() {
            _gameObjectEventChannel.eventRaised -= Respond;   
        }

        void Respond(GameObject obj) {
            _response.Invoke(obj);
        }
    }
}