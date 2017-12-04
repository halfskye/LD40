using Assets.Scripts;
using UnityEngine;

public class Presents : MonoBehaviour {

    private float floorCleanup;
    private bool _isOngGround = false;
    private Transform _presentTranform;

    // Use this for initialization
    void Start () {
        _presentTranform = transform;
        floorCleanup = -7.13f;
	}

    private void FixedUpdate()
    {
        if (transform.position.x <= floorCleanup)
        {
            _isOngGround = false;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (_isOngGround)
        {
            _presentTranform.Translate(-HouseRando.Get().GetHouseSpeed() * Time.deltaTime, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "House")
        {
            Die();
        }

        if (collision.gameObject.tag == "Floor")
        {
            _isOngGround = true;
        }

        if (collision.gameObject.name == "Chimney")
        {
            EnterChimney();
        }
    }

    private void EnterChimney() {

        PresentController.Get().ChimneyExploder(transform.position);
        Player player = Player.Get();
        player.PresentDelivered();
        SoundController.Chimney.Play();
        gameObject.SetActive(false);  
    }

    private void Die()
    {
        if (CameraShake.ReturnShake() != null)
        {
            CameraShake.ReturnShake().Shake(0.05f, 0.1f);
            SoundController.PresentHouseHit.Play();
            PresentController.Get().SpawnExploder(transform.position);
            gameObject.SetActive(false);   
        }
        else
        {
            Debug.Log("Cam Script is null");
        }
    }
}
