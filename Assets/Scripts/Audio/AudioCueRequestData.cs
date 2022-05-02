using UnityEngine;

namespace BrieYourself.Audio {
    public readonly struct AudioCueRequestData {
        public readonly AudioCueSo audioCue;
        public readonly AudioConfigSo audioConfig;
        public readonly Vector3 position;

        public AudioCueRequestData(AudioCueSo audioCue, AudioConfigSo audioConfig, Vector3 position = default) {
            this.audioCue = audioCue;
            this.audioConfig = audioConfig;
            this.position = position;
        }
    }
}