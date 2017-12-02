using UnityEngine;

public class BgRepeat : MonoBehaviour {

    private BoxCollider2D _backgroundCollider;
    private float _bgSize;

	// Use this for initialization
	void Start () {
        _backgroundCollider = GetComponent<BoxCollider2D>();
        _bgSize = _backgroundCollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -_bgSize)
        {
            RepeatBG();
        }
	}

    void RepeatBG()
    {
        Vector3 bgOffset = new Vector3(_bgSize * 2f, 0);
        transform.position += bgOffset;
    }
}
