using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseClasses;


namespace Managers
{
    public class SoundLibrary : BaseSingleton<SoundLibrary>
    {

        public Dictionary<SoundEnum, WSound> SoundDic;
        public List<WSound> WSounds;


        private void Start()
        {
            SoundDic = new Dictionary<SoundEnum, WSound>();

            foreach (SoundEnum sEnum in Enum.GetValues(typeof(SoundEnum)))
            {
                foreach (var sound in WSounds)
                {
                    if (sound.Name == sEnum.ToString())
                        SoundDic.Add(sEnum, sound);
                }
            }
        }

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

        public string[] Enums
        {
            get
            {
                List<string> e = new List<string>();
                foreach (var sound in WSounds)
                {
                    e.Add(sound.Name);
                }
                return e.ToArray();
            }
        }
    }
}

public enum VibrationType
{
    shaking,
    soft,
    none,
}

