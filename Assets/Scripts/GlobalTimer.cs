using UnityEngine;

public class GlobalTimer : MonoBehaviour {

    private static GlobalTimer Singleton;

    public float _timeTotal;

    private string _timerString;

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
        Rect rect = new Rect(0, 28, 50, 50);
        GUIStyle guiStyle = GUIStyle.none;
        guiStyle.normal.textColor = Color.white;

        GUI.TextArea(rect, "Time: " + _timerString, guiStyle);
    }
}
