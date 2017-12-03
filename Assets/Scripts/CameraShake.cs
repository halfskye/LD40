using UnityEngine;

public class CameraShake : MonoBehaviour {

    public Camera mainCam;

    private float _shakeAmount = 0;

    private static CameraShake Singleton;

    private void Awake()
    {
        Singleton = this;

        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    public static CameraShake ReturnShake()
    {
        return Singleton;
    }

    public void Shake(float amount, float length)
    {
        _shakeAmount = amount;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void BeginShake()
    {
        if (_shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            var offsetX = Random.value * _shakeAmount * 2 - _shakeAmount;
            var offsetY = Random.value * _shakeAmount * 2 - _shakeAmount;

            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}
