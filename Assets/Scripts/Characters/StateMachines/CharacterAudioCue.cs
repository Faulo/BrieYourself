using BrieYourself.Audio;
using MyBox;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace BrieYourself.Characters.StateMachines {
    public class CharacterAudioCue : CharacterBehaviour {
        [Header("Playback")]
        [SerializeField, Expandable]
        AudioCueSo audioCue = default;
        [SerializeField, Expandable]
        AudioConfigSo audioConfig = default;
        [SerializeField, Expandable]
        AudioCueRequestEventChannel audioChannel = default;

        [Header("Timing")]
        [SerializeField]
        bool playOnEnter = false;
        [Space]
        [SerializeField]
        bool playOnUpdate = false;
        [SerializeField, ConditionalField(nameof(playOnUpdate))]
        float delayBetweenCues = 1;
        [Space]
        [SerializeField]
        bool playOnExit = false;

        float timer;

        protected override void StateEnter(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (playOnEnter) {
                Raise();
            }
            timer = delayBetweenCues;
        }
        protected override void StateUpdate(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (playOnUpdate) {
                timer -= Time.deltaTime;
                if (timer < 0) {
                    timer = delayBetweenCues;
                    Raise();
                }
            }
        }
        protected override void StateExit(in AnimatorStateInfo stateInfo, int layerIndex) {
            if (playOnExit) {
                Raise();
            }
        }

        void Raise() {
            audioChannel.RequestAudio(new AudioCueRequestData(audioCue, audioConfig, character.transform.position));
        }
    }
}