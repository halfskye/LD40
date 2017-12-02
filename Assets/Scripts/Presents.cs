using System.Collections;
using System.Collections.Generic;
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
            Destroy(gameObject);
        }

    }
}
