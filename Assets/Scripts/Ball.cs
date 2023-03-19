using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

  Vector2 direction = Vector2.one.normalized;
  GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    gameManager = FindObjectOfType<GameManager>();
  }

  // Called when the ball collides with something
  private void OnCollisionEnter2D(Collision2D collision)
  {
    print("Ball collided with " + collision.gameObject.name);
    // If the ball collides with the out of bounds check, add a point to the other player
    if (collision.gameObject.name == "OutBoundsCheckA")
    {
      gameManager.scoreB();
      Destroy(gameObject);
      return;
    }
    else if (collision.gameObject.name == "OutBoundsCheckB")
    {
      gameManager.scoreA();
      Destroy(gameObject);
      return;
    }
  }

}
