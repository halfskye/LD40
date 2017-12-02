using UnityEngine;

public class Presents : MonoBehaviour {

    private float floorCleanup;

    // Use this for initialization
    void Start () {
        floorCleanup = -5f;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (transform.position.y < floorCleanup)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Chimney")
        {       
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "House")
        {
            ShakeCamera(Camera.main.gameObject);
        }
    }

    private void ShakeCamera(GameObject obj)
    {
        obj.GetComponent<CameraScript>().ShakeCam();
    }
}
