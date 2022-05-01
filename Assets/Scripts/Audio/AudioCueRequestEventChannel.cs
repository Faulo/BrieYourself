using System;
using UnityEngine;

namespace BrieYourself.Audio {
    [CreateAssetMenu(fileName = "CH_new_AudioCueRequestChannel", menuName = "Channels/AudioCueRequestChannel", order = 0)]
    public class AudioCueRequestEventChannel : ScriptableAsset {
        public event Action<AudioCueRequestData> onAudioCueRequested;

        public void RequestAudio(AudioCueRequestData audioCueRequestData) {
            onAudioCueRequested?.Invoke(audioCueRequestData);
        }
    }
}

