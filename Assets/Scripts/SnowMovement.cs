using Assets.Scripts;
using UnityEngine;

public class SnowMovement : MonoBehaviour {

    void Update()
    {
        MoveAndSpin();
    }

    private void MoveAndSpin()
    {
        transform.Translate(Vector2.down * 1.5f * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SnowDestroyer")
        {
            gameObject.SetActive(false);
        }
    }
}
