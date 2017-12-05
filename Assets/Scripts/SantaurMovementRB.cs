using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;
using System.Collections;
using UnityEngine.SceneManagement;

public class SantaurMovementRB : MonoBehaviour {

    private static SantaurMovementRB Singleton;
    static public SantaurMovementRB Get() { return Singleton; }

    public float thrust;
    public float downThrust;
    public float boost;
    public Rigidbody2D rb;
    public float leftWall;
    public float rightWall;
    public float ceiling;

    private bool _keyLeft() { return (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)); }
    private bool _keyRight() { return (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)); }
    private bool _keyDown() { return (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)); }
    private bool _keyPresents() { return (Input.GetKeyDown(KeyCode.Space)); }

    //Object Pooling
    public GameObject[] Presents;
    private List<GameObject> _presentPool;
    public int PresentAmountEach = 100;

    private Player _player = null;

    public float FireRate;
    private float _nextFire;

    public bool isDead = false;

    public void Awake()
    {
        Singleton = this;
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        thrust = 21;
        downThrust = 14;
        boost = 150;
        rb.drag = 3;
        rb.gravityScale = .2f;
        leftWall = -5;
        rightWall = 5;
        ceiling = 3.2f;

        _presentPool = new List<GameObject>();
        foreach (var present in Presents)
        {
            for (int j = 0; j < PresentAmountEach; j++)
            {
                GameObject obj = Instantiate(present);
                obj.SetActive(false);
                _presentPool.Add(obj);
            }
        }

        _player = Player.Get();
    }

	// Update is called once per frame
	void Update () {

        Movement();
        Barriers();

        if (_keyPresents() && _player.HasPresents() && (Time.time > _nextFire))
        {
            _nextFire = Time.time + FireRate;
            SpawnPresent();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "House" || collision.gameObject.name == "Chimney")
        {
            SoundController.SantaurThud.Play();

            PresentController.Get().SpawnExploder(transform.position);
            PresentController.Get().SpawnExploder(transform.position);
            PresentController.Get().SpawnExploder(transform.position);
            PresentController.Get().SpawnExploder(transform.position);
            PresentController.Get().SpawnExploder(transform.position);
            PresentController.Get().SpawnExploder(transform.position);

            Destroy(gameObject);
        }
    }

    //Controls player with RigidBody2D
    public void Movement()
    {
        if (_keyRight())
        {
            rb.AddForce(Vector2.right * thrust);
        }

        if (_keyLeft())
        {
            rb.AddForce(Vector2.left * thrust);
        }

        if (_keyDown())
        {
            rb.AddForce(Vector2.down * downThrust);
        }
    }

    //Prevents player from leaving the play area
    public void Barriers()
    {
        if (transform.position.x < leftWall)
        {
            Vector2 pos = transform.position;
            pos.x = leftWall;
            transform.position = pos;
        }
        if (transform.position.x > rightWall)
        {
            Vector2 pos = transform.position;
            pos.x = rightWall;
            transform.position = pos;
        }
        if (transform.position.y > ceiling)
        {
            Vector2 pos = transform.position;
            pos.y = ceiling;
            transform.position = pos;
        }
    }

    //Spawns present beneath the sleigh
    public void SpawnPresent()
    {
        if (_presentPool != null)
        {
            GameObject obj = GetPooledObject();
            if (obj != null)
            {
                //Boost ship up
                rb.AddForce(Vector2.up * boost);
                SoundController.ReleasePresent.Play();

                //Activate Pooled Present
                var pos = new Vector2(transform.position.x - .6f, transform.position.y - .47f);
                obj.transform.position = pos;
                obj.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Add a Present Object to the SantaurMovementRB Script JackoFFFF!!!!");
        }

        Player player = Player.Get();
        player.UsePresent();
    }

    public GameObject GetPooledObject()
    {
        if (_presentPool != null)
        {
            GameObject gameObj = _presentPool[Random.Range(0, _presentPool.Count)];
            if (!gameObj.activeInHierarchy)
            {
                return gameObj;
            }
        }
        return null;
    }
}
