using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaurMovement : MonoBehaviour {

    public float gravity;
    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public float accel;

    private bool _keyLeft() { return (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)); }
    private bool _keyRight() { return (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)); }

    // Use this for initialization
    void Start () {
        speed = .05f;
        maxSpeed = .08f;
        minSpeed = 0.001f;
        accel = .002f;
	}
	
	// Update is called once per frame
	void Update () {

        Movement();

    }

    private void Movement()
    {
        if (_keyRight() && !_keyLeft())
        {
            //speed += accel;
            transform.Translate(Vector2.right * speed);

            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
       

        if (_keyLeft() && !_keyRight())
        {
            //speed += accel;
            transform.Translate(Vector2.left * speed);

            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }

        }
}
