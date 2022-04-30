using UnityEngine;

namespace BrieYourself.Audio
{
    public class AudioCue : MonoBehaviour
    {
        [SerializeField] private bool _playOnStart;
        [SerializeField] private AudioCueSo _audioCue;
        [SerializeField] private AudioConfigSo _audioConfig;
        [SerializeField] private AudioCueRequestEventChannel _audioCueChannel;

        private void Start()
        {
            if(_playOnStart)
                RequestAudio(transform.position);
        }
        
        private void RequestAudio(Vector3 position)
        {
            var data = new AudioCueRequestData(_audioCue, _audioConfig, position);
            _audioCueChannel.RequestAudio(data);
        }

        public void PlayAudioCue()
        {
            RequestAudio(transform.position);
        }

        public void PlayAudioCue(Vector3 position)
        {
            RequestAudio(position);
        }
    }
}