using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaurMovementRB : MonoBehaviour {

    public float thrust;
    public float boost;
    public Rigidbody2D rb;
    public float leftWall;
    public float rightWall;
    public float ceiling;

    private bool _keyLeft() { return (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)); }
    private bool _keyRight() { return (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)); }
    private bool _keyPresents() { return (Input.GetKeyDown(KeyCode.Space)); }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        thrust = 7;
        boost = 150;
        rb.drag = 3;
        rb.gravityScale = .2f;
        leftWall = -5;
        rightWall = 5;
        ceiling = 3.2f;
	}
	
	// Update is called once per frame
	void Update () {
              
        Movement();
        Barriers();
        
        if (_keyPresents())
        {
            SpawnPresent();
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
        var pos = new Vector2(transform.position.x - .6f, transform.position.y - .47f);
        Instantiate(Resources.Load("Presents"), pos, transform.rotation);
        rb.AddForce(Vector2.up * boost);
    }
}
