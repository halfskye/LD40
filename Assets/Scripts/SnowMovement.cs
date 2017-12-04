using Assets.Scripts;
using UnityEngine;

public class SnowMovement : MonoBehaviour {

    void Update()
    {
        transform.Rotate(Vector3.left * Time.deltaTime * 10);
        transform.Translate(Vector2.down * SnowRando.Get().GetSnowSpeed() * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SnowDestroyer")
        {
            gameObject.SetActive(false);
        }
    }
}
