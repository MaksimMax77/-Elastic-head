using System;
using UnityEngine;

namespace Code.Actor.Animation
{
    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action<string> AnimationEventInvoked;

        public void OnAnimationEvent(string eventName)
        {
            AnimationEventInvoked?.Invoke(eventName);
        }
    }
}