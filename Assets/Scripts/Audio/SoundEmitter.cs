using System;
using System.Collections;
using UnityEngine;

namespace BrieYourself.Audio {
    [RequireComponent(typeof(AudioSource))]
    public class SoundEmitter : MonoBehaviour {
        AudioSource _audioSource;

        public event Action<SoundEmitter> onSoundFinishedPlaying;

        protected void Awake() {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.playOnAwake = false;

        }

        public void PlayAudioClip(AudioClip audioClip, AudioConfigSo config, bool hasToLoop, Vector3 position = default) {
            _audioSource.clip = audioClip;
            config.ApplyConfigToAudioSource(_audioSource);
            _audioSource.transform.position = position;
            _audioSource.loop = hasToLoop;
            _audioSource.Play();

            if (hasToLoop) {
                return;
            }

            StartCoroutine(FinishedPlayingEnumerator(audioClip.length));
        }

        public void Resume() {
            _audioSource.Play();
        }

        public void Pause() {
            _audioSource.Pause();
        }

        public void Stop() {
            _audioSource.Stop();
        }

        public bool IsLooping() {
            return _audioSource.loop;
        }

        public bool IsPlaying() {
            return _audioSource.isPlaying;
        }

        public void SetVolume(float volume) {
            _audioSource.volume = Mathf.Clamp01(volume);
        }

        public float GetVolume() {
            return _audioSource.volume;
        }

        IEnumerator FinishedPlayingEnumerator(float clipLength) {
            yield return new WaitForSeconds(clipLength);
            onSoundFinishedPlaying?.Invoke(this);
        }
    }
}