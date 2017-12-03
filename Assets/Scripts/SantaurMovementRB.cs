﻿using UnityEngine;
using System.Collections.Generic;

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

    //Object Pooling
    public GameObject present;
    private List<GameObject> _presentPool;
    public int PresentAmountTotal = 100;

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

        _presentPool = new List<GameObject>();
        for (int j = 0; j < PresentAmountTotal; j++)
        {
            GameObject obj = Instantiate(present);
            obj.SetActive(false);
            _presentPool.Add(obj);
        }
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
        if (_presentPool != null)
        {
            GameObject obj = GetPooledObject();
            if (obj != null)
            {
                //Boost ship up
                rb.AddForce(Vector2.up * boost);

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
        for (int i = 0; i < _presentPool.Count; i++)
        {
            if (!_presentPool[i].activeInHierarchy)
            {
                return _presentPool[i];
            }
        }
        return null;
    }
}
