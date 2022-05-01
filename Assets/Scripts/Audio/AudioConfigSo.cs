using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace BrieYourself.Audio {
    [CreateAssetMenu(fileName = "new Audio Config", menuName = "Audio/AudioConfig", order = 0)]
    public class AudioConfigSo : ScriptableAsset {
        public AudioMixerGroup outputAudioMixerGroup = null;
        [SerializeField]
        PriorityLevel _priorityLevel = PriorityLevel.Standard;

        int priority {
            get => (int)_priorityLevel;
            set => _priorityLevel = (PriorityLevel)value;
        }

        [FormerlySerializedAs("Mute")]
        [Header("Sound properties")]
        [SerializeField]
        bool mute = false;

        [Space]
        [SerializeField, Range(0f, 1f)]
        float volumeMinimum = 1f;
        [SerializeField, Range(0f, 1f)]
        float volumeMaximum = 1f;
        public float volume => Random.Range(volumeMinimum, volumeMaximum);

        [Space]
        [SerializeField, Range(-3f, 3f)]
        float pitchMinimum = 1f;
        [SerializeField, Range(-3f, 3f)]
        float pitchMaximum = 1f;
        float pitch => Random.Range(pitchMinimum, pitchMaximum);

        [Space]
        [SerializeField, Range(-1f, 1f)]
        float panStereo = 0f;
        [SerializeField, Range(0f, 1.1f)]
        float reverbZoneMix = 1f;

        [Header("Spatial settings")]
        [SerializeField, Range(0f, 1f)]
        float spatialBlend = 0f;
        [SerializeField, Range(0f, 5f)]
        float dopplerLevel = 1f;
        [SerializeField, Range(0f, 360f)]
        float spread = 0f;
        [SerializeField]
        AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic;
        [SerializeField]
        float minDistance = 1;
        [SerializeField]
        float maxDistance = 500;

        [Header("Ignores")]
        public bool bypassEffects = false;
        public bool bypassListenerEffects = false;
        public bool bypassReverbZones = false;
        public bool ignoreListenerVolume = false;
        public bool ignoreListenerPause = false;

        enum PriorityLevel {
            Highest = 0,
            High = 64,
            Standard = 128,
            Low = 194,
            Lowest = 256
        }

        public void ApplyConfigToAudioSource(AudioSource audioSource) {
            audioSource.outputAudioMixerGroup = outputAudioMixerGroup;
            audioSource.mute = mute;
            audioSource.bypassEffects = bypassEffects;
            audioSource.bypassListenerEffects = bypassListenerEffects;
            audioSource.bypassReverbZones = bypassReverbZones;
            audioSource.priority = priority;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.panStereo = panStereo;
            audioSource.spatialBlend = spatialBlend;
            audioSource.reverbZoneMix = reverbZoneMix;
            audioSource.dopplerLevel = dopplerLevel;
            audioSource.spread = spread;
            audioSource.rolloffMode = rolloffMode;
            audioSource.minDistance = minDistance;
            audioSource.maxDistance = maxDistance;
            audioSource.ignoreListenerVolume = ignoreListenerVolume;
            audioSource.ignoreListenerPause = ignoreListenerPause;
        }
    }
}