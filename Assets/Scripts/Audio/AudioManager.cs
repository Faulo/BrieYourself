using System;
using System.Collections;
using BrieYourself.Pooling;
using UnityEngine;

namespace BrieYourself.Audio {
    public class AudioManager : MonoBehaviour {
        [SerializeField] AudioCueRequestEventChannel _sfxChannel;
        [SerializeField] AudioCueRequestEventChannel _musicChannel;
        [SerializeField] GameObject _soundEmitterPrefab;
        GameObjectPool _soundEmitterPool;
        SoundEmitter _currentMusicTrack;

        protected void Awake() {
            _soundEmitterPool = new GameObjectPool(transform, _soundEmitterPrefab, 32);
        }

        protected void OnEnable() {
            _sfxChannel.onAudioCueRequested += PlayAudioCue;
            _musicChannel.onAudioCueRequested += PlayMusic;
        }

        protected void OnDisable() {
            _sfxChannel.onAudioCueRequested -= PlayAudioCue;
            _musicChannel.onAudioCueRequested -= PlayMusic;
        }

        void PlayAudioCue(AudioCueRequestData audioCueRequestData) {
            var clipsToPlay = audioCueRequestData.audioCue.GetClips();
            int numberOfClips = clipsToPlay.Length;

            for (int i = 0; i < numberOfClips; i++) {
                var soundEmitter = _soundEmitterPool.RequestInstance().GetComponent<SoundEmitter>();

                if (soundEmitter == null) {
                    return;
                }

                soundEmitter.PlayAudioClip(clipsToPlay[i], audioCueRequestData.audioConfig,
                    audioCueRequestData.audioCue.looping, audioCueRequestData.position);

                if (!audioCueRequestData.audioCue.looping) {
                    soundEmitter.onSoundFinishedPlaying += OnSoundEmitterFinishedPlaying;
                }
            }
        }

        void PlayMusic(AudioCueRequestData audioCueRequestData) {

            var clipsToPlay = audioCueRequestData.audioCue.GetClips();
            int numberOfClips = clipsToPlay.Length;

            for (int i = 0; i < numberOfClips; i++) {
                var newMusicTrack = _soundEmitterPool.RequestInstance().GetComponent<SoundEmitter>();

                if (newMusicTrack == null) {
                    return;
                }

                if (_currentMusicTrack != null && _currentMusicTrack.IsPlaying()) {
                    FadeOut(_currentMusicTrack, 0.5f, obj => {
                        _soundEmitterPool.ReturnInstance(obj);
                    });
                }

                _currentMusicTrack = newMusicTrack;
                _currentMusicTrack.PlayAudioClip(clipsToPlay[i], audioCueRequestData.audioConfig,
                    audioCueRequestData.audioCue.looping, audioCueRequestData.position);
                FadeIn(_currentMusicTrack, audioCueRequestData.audioConfig.volume, 0.5f);

                if (!audioCueRequestData.audioCue.looping) {
                    newMusicTrack.onSoundFinishedPlaying += OnSoundEmitterFinishedPlaying;
                }
            }
        }

        void FadeOut(SoundEmitter soundEmitter, float durationInSeconds, Action<GameObject> fadeOutFinished = default) {
            StartCoroutine(FadeOutEnumerator(soundEmitter, durationInSeconds, fadeOutFinished));
        }

        IEnumerator FadeOutEnumerator(SoundEmitter soundEmitter, float durationInSeconds, Action<GameObject> fadeOutFinished) {
            for (float volume = soundEmitter.GetVolume(); volume > 0; volume -= Time.deltaTime / durationInSeconds) {
                soundEmitter.SetVolume(volume);
                yield return null;
            }
            fadeOutFinished?.Invoke(soundEmitter.gameObject);
        }

        void FadeIn(SoundEmitter soundEmitter, float volume, float durationInSeconds, Action<GameObject> fadeInFinished = default) {
            StartCoroutine(FadeInEnumerator(soundEmitter, volume, durationInSeconds, fadeInFinished));
        }

        IEnumerator FadeInEnumerator(SoundEmitter soundEmitter, float volume, float durationInSeconds, Action<GameObject> fadeInFinished) {
            for (float vol = 0; vol < volume; vol += Time.deltaTime / durationInSeconds) {
                soundEmitter.SetVolume(volume);
                yield return null;
            }
            fadeInFinished?.Invoke(soundEmitter.gameObject);
        }

        void OnSoundEmitterFinishedPlaying(SoundEmitter soundEmitter) {
            soundEmitter.onSoundFinishedPlaying -= OnSoundEmitterFinishedPlaying;
            soundEmitter.Stop();
            _soundEmitterPool.ReturnInstance(soundEmitter.gameObject);
        }
    }
}