using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseClasses;
using Managers;

public class SoundPlayerManager : BaseSingleton<SoundPlayerManager>
{
    object _cookieObject;

    public void PlaySound(SoundEnum s,GameObject g)
    {
        StartCoroutine(AnimateSound(s,g));
        
    }


    public void SwitchSound(SoundEnum horn, SoundEnum obj)
    {

    }
    IEnumerator AnimateSound(SoundEnum s, GameObject g)
    {
        AkSoundEngine.PostEvent(s.ToString(), g,AkCallbackType.AK_EndOfEvent,CallbackEvent,);
        SoundLibrary.WSound chosenSound;
        SoundLibrary.Instance.SoundDic.TryGetValue(s, out chosenSound);


        yield return null;
    }
    private void CallbackEvent()
    {

    }


}
