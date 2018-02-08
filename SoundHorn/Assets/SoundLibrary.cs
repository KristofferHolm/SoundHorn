using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum VibrationType
{
    shaking,
    soft,
    none,
}

public class SoundLibrary : MonoBehaviour {

    public AnimationCurve ac;

    public List<WSound> Level1;
    public List<WSound> Level2;

    [Serializable]
    public class WSound
    {
        public string Name;
        public VibrationType Vibration;
        public List<StateChange> StepState;
        [Serializable]
        public class StateChange
        {
            public float Timestep;
            public VibrationType VibrationStep;
            public bool TextureStep;
        }
    }
}
