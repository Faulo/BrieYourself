using System;
using UnityEngine;

namespace BrieYourself.Channels {
    [CreateAssetMenu(fileName = "CH_New_GameObjectEventChannel", menuName = "Channels/GameObjectEventChannel", order = 0)]
    public class GameObjectEventChannel : ScriptableAsset {
        public Action<GameObject> eventRaised;

        public void Raise(GameObject gameObject) {
            eventRaised?.Invoke(gameObject);
        }
    }
}