using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GlobalTimer : MonoBehaviour {

    private static GlobalTimer Singleton;
    static public GlobalTimer Get() { return Singleton; }

    public Object Santaur;

    public float _timeTotal;

    private string _timerString;

    [SerializeField]
    private TextMesh _timer = null;

    public void Awake()
    {
        Singleton = this;

    }

    private void Update()
    {
        _timeTotal -= Time.deltaTime;

        var seconds = (int)(_timeTotal % 60);
        var minutes = (int)(_timeTotal / 60) % 60;

        _timerString = string.Format("{0:00}:{1:00}", minutes,seconds);
        _timer.text = _timerString;

        if (!Santaur)
        {
            StartCoroutine(LoadNextLevel(1f, "EndScene"));
        }

        if (_timeTotal <= 0)
        {
            SceneManager.LoadScene("EndTimeScene");
        }
    }

    public static GlobalTimer Timer()
    {
        return Singleton;
    }

    public void OnGUI()
    {
        
    }

    IEnumerator LoadNextLevel(float delay, string level)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(level);
    }
}
