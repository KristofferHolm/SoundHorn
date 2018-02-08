using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundContainer : MonoBehaviour {
    // Use this for initialization
    AkAmbient ak;
    void Start () {
        ak = GetComponentInChildren<AkAmbient>();
      

	}
    private void OnCollisionEnter(Collision collision)
    {
        AkSoundEngine.PostEvent((uint)ak.eventID, gameObject);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
