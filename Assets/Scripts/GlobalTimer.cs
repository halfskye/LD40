using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour {

    private static GlobalTimer Singleton;

    [SerializeField]
    private float _timeTotal = 2.0f;
    public float CurrentTime;

    public Text TimerText;

    private int _seconds;
    private int _minutes;
    private string _timerString;

    public void Awake()
    {
        Singleton = this;
    }

    private void Update()
    {
        _timeTotal -= Time.deltaTime;
        CurrentTime = _timeTotal;

        _minutes = (int)(_timeTotal % 60);
        _seconds = (int)(_timeTotal / 60) % 60;

        _timerString = string.Format("{1:00}:{2:00}", _minutes,_seconds);
    }

    public static GlobalTimer Timer()
    {
        return Singleton;
    }
}
