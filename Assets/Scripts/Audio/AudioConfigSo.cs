using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace BrieYourself.Audio {
    [CreateAssetMenu(fileName = "new Audio Config", menuName = "Audio/AudioConfig", order = 0)]
    public class AudioConfigSo : ScriptableAsset {
        public AudioMixerGroup outputAudioMixerGroup = null;
        [SerializeField] PriorityLevel _priorityLevel = PriorityLevel.Standard;

        [HideInInspector]
        public int Priority {
            get { return (int)_priorityLevel; }
            set { _priorityLevel = (PriorityLevel)value; }
        }

        [FormerlySerializedAs("Mute")]
        [Header("Sound properties")]
        public bool mute = false;
        [Range(0f, 1f)] public float volume = 1f;
        [Range(-3f, 3f)] public float pitch = 1f;
        [Range(-1f, 1f)] public float panStereo = 0f;
        [Range(0f, 1.1f)] public float reverbZoneMix = 1f;

        [Header("Spatial settings")]
        [Range(0f, 1f)] public float spatialBlend = 0f;
        [Range(0f, 5f)] public float dopplerLevel = 1f;
        [Range(0f, 360f)] public float spread = 0f;
        public AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic;
        [Range(0.1f, 5f)] public float minDistance = 0.1f;
        [Range(5f, 100f)] public float maxDistance = 50f;

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
            audioSource.priority = Priority;
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