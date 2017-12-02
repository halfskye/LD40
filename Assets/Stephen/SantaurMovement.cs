using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaurMovement : MonoBehaviour {

    public float Gravity;
    public float Speed;

    private bool _keyLeft() { return (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)); }
    private bool _keyRight() { return (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)); }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if _keyRight(
        transform.Translate(Vector2.right * Speed);
        )
    }
}
