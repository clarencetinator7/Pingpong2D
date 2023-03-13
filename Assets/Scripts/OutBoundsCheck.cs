using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBoundsCheck : MonoBehaviour
{

  private void OnTriggerEnter2D(Collider2D other)
  {
    print("Ball detected");
    if (other.gameObject.CompareTag("Ball"))
    {
      Destroy(other.gameObject);
      // Respawns the ball
    }
  }

}
