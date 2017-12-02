using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour {

    private Rigidbody2D _rigidBody;
    [SerializeField]
    private bool _stopScrolling;

    public float Speed = 0.5F;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = new Vector2(-Speed, 0);
    }

    // Update is called once per frame
    void Update () {
        if (_stopScrolling)
        {
            _rigidBody.velocity = Vector2.zero;
        }
        else
        {
            _rigidBody.velocity = new Vector2(-Speed, 0);
        }
	}
}
