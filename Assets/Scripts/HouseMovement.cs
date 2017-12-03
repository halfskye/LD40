using UnityEngine;

public class HouseMovement : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * Speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "HouseDestroyer")
        {
            gameObject.SetActive(false);
        }
    }
}
