using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEffects : MonoBehaviour
{
    public class SoundSystem
    {
        public int Volume { get; private set; } = 50;
        public bool IsMuted { get; private set; } = false;

        public void SetVolume(int value)
        {
            if (value >= 0 && value <= 100)
                Volume = value;
        }

        public void Mute()
        {
            IsMuted = true;
        }

        public void Unmute()
        {
            IsMuted = false;
        }
    }

    public class AnimationSystem
    {
        public string CurrentAnimation { get; private set; } = "Idle";

        public void PlayAnimation(string animationName)
        {
            CurrentAnimation = animationName;
        }
    }

    public class EffectsSystem
    {
        public bool IsEffectPlaying { get; private set; } = false;

        public void PlayEffect()
        {
            IsEffectPlaying = true;
        }

        public void StopEffect()
        {
            IsEffectPlaying = false;
        }
    }
}
