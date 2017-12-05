using Assets.Scripts;
using UnityEngine;

public class SnowMovement : MonoBehaviour {

    private float _rotationSpeed = 5;

    void Update()
    {
        transform.Translate(Vector2.down * 5 * Time.deltaTime);

        var angle = (Mathf.Sin(Time.time * _rotationSpeed) + 1.0) / 2.0 * 360;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, _rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SnowDestroyer")
        {
            gameObject.SetActive(false);
        }
    }
}
