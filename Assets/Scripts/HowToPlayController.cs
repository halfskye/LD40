using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HowToPlayController : MonoBehaviour {

    private bool _select() { return (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)); }

    public static AudioSource Select;
    private bool _startSelect;
    private bool _nextScene;


    // Use this for initialization
    void Awake () {

        _nextScene = false;
        _startSelect = false;
        StartCoroutine(WaitForTitle());
        AudioSource[] audio = GetComponents<AudioSource>();
        Select = audio[0];
        Select.volume = .4f;

    }
	
	// Update is called once per frame
	void Update () {

        if (_select() && (_nextScene == false) && _startSelect == true)
        {
            _nextScene = true;
            StartCoroutine(WaitForNextScene());
        }

    }

    IEnumerator WaitForTitle()
    {
        yield return new WaitForSeconds(2.5f);
        _startSelect = true;

    }

    IEnumerator WaitForNextScene()
    {
        TitleController.SantaursSleigh.Stop();
        Select.Play();
        Debug.Log("Waiting");
        yield return new WaitForSeconds(2f);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("TS");
    }
}
