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
    private float _inputDelay;
    public GameObject ZMLogo;
    public GameObject House;
    public GameObject Controls;

    // Use this for initialization
    void Awake () {
        //DontDestroyOnLoad(this);
        ZMLogo = Instantiate(Resources.Load("back1")) as GameObject;
        
        _inputDelay = 11.2f;
        _nextScene = false;
        _startSelect = false;
        StartCoroutine(WaitForTitle());
        StartCoroutine(DestroyZMLogo());
        StartCoroutine(ShowTitleCard());
        StartCoroutine(ShowControls());
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
                StartCoroutine(WaitForNextScene());
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

    IEnumerator DestroyZMLogo()
    {
        yield return new WaitForSeconds(5.8f);
        GameObject.Destroy(ZMLogo);
    }

    IEnumerator ShowTitleCard()
    {
        //Destroy ZM logo and display title card
        yield return new WaitForSeconds(11.55f);
        //Resources.UnloadAsset(ZMLogo);
        House = Instantiate(Resources.Load("Title_000")) as GameObject;
        
        //TitleCard = Instantiate(Resources.Load("Title/TITLE")) as GameObject;
    }

    IEnumerator ShowControls()
    {
        //yield return new WaitForSeconds(22.95f);
        yield return new WaitForSeconds(20f);
        GameObject.Destroy(House);
        Controls = Instantiate(Resources.Load("controls")) as GameObject;
    }

    IEnumerator WaitForTitle()
    {
        yield return new WaitForSeconds(11.5f);
        _startSelect = true;
        
    }

    IEnumerator WaitForNextScene()
    {
        Select.Play();
        SantaursSleigh.Stop();
        Debug.Log("Waiting");
        yield return new WaitForSeconds(2.8f);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("TS");
    }

}
