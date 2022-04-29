using System;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Events;

namespace Channels {
    public class GameObjectEventListener : MonoBehaviour {
        [SerializeField, Expandable()] 
        GameObjectEventChannel _gameObjectEventChannel;
        [SerializeField]
        UnityEvent<GameObject> _response;

        void OnEnable() {
            _gameObjectEventChannel.OnEventRaised += Respond;
        }

        void OnDisable() {
            _gameObjectEventChannel.OnEventRaised -= Respond;   
        }

        void Respond(GameObject obj) {
            _response.Invoke(obj);
        }
    }
}