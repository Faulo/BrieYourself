using System;
using UnityEngine;

namespace Channels {
    [CreateAssetMenu(fileName = "CH_New_GameObjectChannel", menuName = "Channels/GameObjectChannel", order = 0)]
    public class GameObjectChannel : ScriptableObject {
        public Action<GameObject> OnEventRaised;

        public void Raise(GameObject gameObject) {
            OnEventRaised?.Invoke(gameObject);
        }
    }
}