using UnityEngine;

public class GlobalTimer : MonoBehaviour {

    private static GlobalTimer Singleton;
    static public GlobalTimer Get() { return Singleton; }

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
    }

    public static GlobalTimer Timer()
    {
        return Singleton;
    }

    public void OnGUI()
    {
        _timer.text = _timerString;
    }
}
