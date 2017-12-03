using UnityEngine;

public class Presents : MonoBehaviour {

    private float floorCleanup;

    // Use this for initialization
    void Start () {
        floorCleanup = -7.13f;
	}

	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < floorCleanup)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "House")
        {
            if (CameraShake.ReturnShake() != null)
            {
                CameraShake.ReturnShake().Shake(0.05f, 0.1f);
            }
            else
            {
                Debug.Log("Cam Script is null");
            }
        }

        if (collision.gameObject.name == "Chimney")
        {
            EnterChimney();
        }
    }

    private void EnterChimney() {
      gameObject.SetActive(false);

      Player player = Player.Get();
      player.PresentDelivered();
    }
}
