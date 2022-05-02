using UnityEngine;

namespace BrieYourself.Audio {
    public class AudioCue : MonoBehaviour {
        [SerializeField] bool _playOnStart;
        [SerializeField] AudioCueSo _audioCue;
        [SerializeField] AudioConfigSo _audioConfig;
        [SerializeField] AudioCueRequestEventChannel _audioCueChannel;

        void Start() {
            if (_playOnStart) {
                RequestAudio(transform.position);
            }
        }

        void RequestAudio(Vector3 position) {
            var data = new AudioCueRequestData(_audioCue, _audioConfig, position);
            _audioCueChannel.RequestAudio(data);
        }

        public void PlayAudioCue() {
            RequestAudio(transform.position);
        }

        public void PlayAudioCue(Vector3 position) {
            RequestAudio(position);
        }
    }
}