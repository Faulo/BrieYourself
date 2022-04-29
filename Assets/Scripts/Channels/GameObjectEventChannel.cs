using System;
using UnityEngine;

namespace Channels {
    [CreateAssetMenu(fileName = "CH_New_GameObjectEventChannel", menuName = "Channels/GameObjectEventChannel", order = 0)]
    public class GameObjectEventChannel : ScriptableObject {
        public Action<GameObject> OnEventRaised;

        public void Raise(GameObject gameObject) {
            OnEventRaised?.Invoke(gameObject);
        }
    }
}