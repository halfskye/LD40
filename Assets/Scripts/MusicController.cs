using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public static AudioSource SpecialDelivery;
    public float StartVolume;

    // Use this for initialization
    void Awake () {

        CheckScene();
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

    public void CheckScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        Debug.Log("Active scene is '" + scene.name + "'.");


        if ((sceneName == "TS"))
        {
            TitleController.SantaursSleigh.Stop();
        }
    }
}
