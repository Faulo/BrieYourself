using BrieYourself.Pooling;
using UnityEngine;

namespace BrieYourself.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioCueRequestEventChannel _sfxChannel;
        [SerializeField] private AudioCueRequestEventChannel _musicChannel;
        [SerializeField] private GameObject _soundEmitterPrefab;
        private GameObjectPool _soundEmitterPool;

        private void Awake() {
            _soundEmitterPool = new GameObjectPool(this.transform, _soundEmitterPrefab, 12);
        }
        
        private void OnEnable()
        {
            _sfxChannel.onAudioCueRequested += PlayAudioCue;
            _musicChannel.onAudioCueRequested += PlayAudioCue;
        }

        private void OnDisable()
        {
            _sfxChannel.onAudioCueRequested -= PlayAudioCue;
            _musicChannel.onAudioCueRequested -= PlayAudioCue;
        }

        private void PlayAudioCue(AudioCueRequestData audioCueRequestData)
        {
            AudioClip[] clipsToPlay = audioCueRequestData.AudioCue.GetClips();
            int numberOfClips = clipsToPlay.Length;

            for (int i = 0; i < numberOfClips; i++)
            {
                SoundEmitter soundEmitter = _soundEmitterPool.RequestInstance().GetComponent<SoundEmitter>();
                
                if (soundEmitter == null) return;
                soundEmitter.PlayAudioClip(clipsToPlay[i], audioCueRequestData.AudioConfig,
                    audioCueRequestData.AudioCue.looping, audioCueRequestData.Position);
                
                if (!audioCueRequestData.AudioCue.looping)
                    soundEmitter.onSoundFinishedPlaying += OnSoundEmitterFinishedPlaying;
            }
        }

        private void PlayMusic(AudioCueRequestData audioCueRequestData)
        {
            
        }

        private void OnSoundEmitterFinishedPlaying(SoundEmitter soundEmitter)
        {
            soundEmitter.onSoundFinishedPlaying -= OnSoundEmitterFinishedPlaying;
            soundEmitter.Stop();
            _soundEmitterPool.ReturnInstance(soundEmitter.gameObject);
        }
    }
}