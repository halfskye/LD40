using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public static AudioSource ReleasePresent;
    public static AudioSource Chimney;
    public static AudioSource PresentHouseHit;

    public float StartVolume = .2f;

	// Use this for initialization
	void Awake () {
        AudioSource[] audio = GetComponents<AudioSource>();

        ReleasePresent = audio[0];
        Chimney = audio[1];
        PresentHouseHit = audio[2];

        StartingVolume();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartingVolume()
    {
        ReleasePresent.volume = StartVolume;
        Chimney.volume = StartVolume;
        PresentHouseHit.volume = StartVolume;
    }

}
