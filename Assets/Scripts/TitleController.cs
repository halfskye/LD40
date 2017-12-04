using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleController : MonoBehaviour {

    private bool _select() { return (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)); }

    public static AudioSource SantaursSleigh;
    public static AudioSource Select;
    public float StartVolume;
    private bool _nextScene;
    private bool _startSelect;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(this);
        _nextScene = false;
        _startSelect = false;
        StartCoroutine(WaitForTitle());
        AudioSource[] audio = GetComponents<AudioSource>();
        SantaursSleigh = audio[0];
        Select = audio[1];
        StartingVolume();
        InitializeAudio();

    }
	
	// Update is called once per frame
	void Update () {
		
        if (_select() && (_nextScene == false) && _startSelect == true)
        {
                WaitForNextScene();
                _nextScene = true;
        }

        }

	

    public void StartingVolume()
    {
        StartVolume = .9f;
        SantaursSleigh.volume = StartVolume;
        Select.volume = .4f;
    }

    public static void InitializeAudio()
    {
        //if (MusicController.SpecialDelivery.isPlaying)
        //{
        //    MusicController.SpecialDelivery.Stop();
        //}

        Debug.Log("Initializing Audio");

        if (!SantaursSleigh.isPlaying)
        {
            Debug.Log("Starting Music");
            SantaursSleigh.loop = true;
            SantaursSleigh.Play();
        }
        else
        {
            Debug.Log("Title music is already playing.");
        }
    }

    IEnumerator WaitForTitle()
    {
        yield return new WaitForSeconds(11.5f);
        _startSelect = true;
        
    }

    public void WaitForNextScene()
    {
        Select.Play();
        //Debug.Log("Waiting");
        //yield return new WaitForSeconds(2f);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("HowToPlayScene");
    }

}
