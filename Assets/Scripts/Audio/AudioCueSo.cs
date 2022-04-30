using System;
using UnityEngine;

namespace BrieYourself.Audio
{
    [CreateAssetMenu(fileName = "new AudioCue", menuName = "Audio/AudioCue", order = 0)]
    public class AudioCueSo : ScriptableAsset
    {
        public bool looping = false;
        [SerializeField] private AudioClipGroup[] _audioClipGroup = default;

        public AudioClip[] GetClips()
        {
            var numberOfClips = _audioClipGroup.Length;
            var resultingClips = new AudioClip[numberOfClips];

            for (int i = 0; i < numberOfClips; i++)
            {
                resultingClips[i] = _audioClipGroup[i].GetNextClip();
            }

            return resultingClips;
        }
    }

    [Serializable]
    public class AudioClipGroup
    {
        public SequenceMode mode;
        public AudioClip[] clips;

        private int _nextClip;
        private int _lastClip;

        public AudioClip GetNextClip()
        {
            if (clips.Length == 1)
                return clips[0];
            
            if (_nextClip == -1)
            {
                _nextClip = (mode == SequenceMode.Sequential) ? 0 : UnityEngine.Random.Range(0, clips.Length);
            }
            else
            {
                switch (mode)
                {
                    case SequenceMode.Random:
                        _nextClip = UnityEngine.Random.Range(0, clips.Length);
                        break;
                    
                    case SequenceMode.RandomNoImmediateRepeat:
                        do
                        {
                            UnityEngine.Random.Range(0, clips.Length);
                        } while (_nextClip == _lastClip);
                        break;
                    
                    case SequenceMode.Sequential:
                        _nextClip = (int) Mathf.Repeat(++_nextClip, clips.Length);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _lastClip = _nextClip;
            return clips[_nextClip];
        }
        
        public enum SequenceMode
        {
            Random, 
            RandomNoImmediateRepeat,
            Sequential
        }
    }
}