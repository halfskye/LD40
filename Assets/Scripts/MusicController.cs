using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public static AudioSource SpecialDelivery;
    public float StartVolume;

    // Use this for initialization
    void Awake () {

        AudioSource[] audio = GetComponents<AudioSource>();

        SpecialDelivery = audio[0];

        StartingVolume();

        SpecialDelivery.loop = true;
        SpecialDelivery.Play();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartingVolume()
    {
        StartVolume = .9f;
        SpecialDelivery.volume = StartVolume;
    }
}
