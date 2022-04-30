using UnityEngine;

namespace BrieYourself.Audio
{
    public readonly struct AudioCueRequestData
    {
        public AudioCueRequestData(AudioCueSo audioCue, AudioConfigSo audioConfig, Vector3 position = default)
        {
            AudioCue = audioCue;
            AudioConfig = audioConfig;
            Position = position;
        }
        public readonly AudioCueSo AudioCue;
        public readonly AudioConfigSo AudioConfig;
        public readonly Vector3 Position;
    }
}