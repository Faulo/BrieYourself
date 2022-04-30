using BrieYourself.Audio;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioCueTester : MonoBehaviour {
    AudioCue _cue;

    protected void Awake() {
        _cue = GetComponent<AudioCue>();
    }

    [ContextMenu("TestAudioCue")]
    void TestAudioCue() {
        _cue.PlayAudioCue();
    }

    protected void Update() {
        if (Keyboard.current.sKey.wasPressedThisFrame) {
            _cue.PlayAudioCue();
        }
    }
}
