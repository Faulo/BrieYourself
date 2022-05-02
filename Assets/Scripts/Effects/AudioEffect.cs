using BrieYourself.Audio;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Effects {
    [CreateAssetMenu]
    public class AudioEffect : ScriptableAsset {
        [Header("Playback")]
        [SerializeField, Expandable]
        AudioCueSo audioCue = default;
        [SerializeField, Expandable]
        AudioConfigSo audioConfig = default;
        [SerializeField, Expandable]
        AudioCueRequestEventChannel audioChannel = default;

        public void Play() {
            audioChannel.RequestAudio(new AudioCueRequestData(audioCue, audioConfig, Vector3.zero));
        }
        public void Play(GameObject context) {
            audioChannel.RequestAudio(new AudioCueRequestData(audioCue, audioConfig, context.transform.position));
        }
    }
}