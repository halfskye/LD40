using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour {

    private bool _select() { return (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)); }

    public static AudioSource SantaursSleigh;
    public float StartVolume;

    // Use this for initialization
    void Awake () {

        AudioSource[] audio = GetComponents<AudioSource>();

        SantaursSleigh = audio[0];
        StartingVolume();
        InitializeAudio();

    }
	
	// Update is called once per frame
	void Update () {
		
        if (_select())
        {

        }

	}

    public void StartingVolume()
    {
        StartVolume = .9f;
        SantaursSleigh.volume = StartVolume;
    }

    public static void InitializeAudio()
    {
        //if (MusicController.SpecialDelivery.isPlaying)
        //{
        //    MusicController.SpecialDelivery.Stop();
        //}

        if (!SantaursSleigh.isPlaying)
        {
            SantaursSleigh.loop = true;
            SantaursSleigh.Play();
        }
        else
        {
            Debug.Log("Title music is already playing.");
        }
    }

}
