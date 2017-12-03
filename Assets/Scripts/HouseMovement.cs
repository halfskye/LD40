using UnityEngine;

namespace Assets.Scripts
{
  public class HouseMovement : MonoBehaviour
  {
      void Update()
      {
          transform.Translate(Vector2.left * HouseRando.Get().GetHouseSpeed() * Time.deltaTime);
      }

      void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.gameObject.name == "HouseDestroyer")
          {
              gameObject.SetActive(false);
          }
      }
  }
}
