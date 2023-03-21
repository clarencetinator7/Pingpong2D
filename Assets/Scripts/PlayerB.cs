using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour
{
  [SerializeField] float paddleSpeed = 5f;
  [SerializeField] float bounds = 3.5f;
  float hitCount = 0;

  // Update is called once per frame
  void Update()
  {
    // Move paddle up or down on key press
    if (Input.GetKey(KeyCode.UpArrow))
    {
      transform.Translate(Vector2.up * paddleSpeed * Time.deltaTime);
    }
    else if (Input.GetKey(KeyCode.DownArrow))
    {
      transform.Translate(Vector2.down * paddleSpeed * Time.deltaTime);
    }

    // Keep paddle within screen bounds using clamp
    float y = Mathf.Clamp(transform.position.y, -(bounds), bounds);
    transform.position = new Vector2(transform.position.x, y);

  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Ball"))
    {
      // Shake camera on collision
      Camera.main.GetComponent<CameraShake>().Shake(0.1f);

      hitCount++;
      // if hitCount > 5, decrease paddle size
      if (hitCount > 5 && transform.localScale.y > 2.0f)
      {
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y - 0.1f);
        // adjust the bounds to match the new paddle size
        bounds = bounds + 0.05f;
      }
    }
  }

  public void Reset()
  {
    // Reset paddle size
    transform.localScale = new Vector2(transform.localScale.x, 3.0f);
    // Reset bounds
    bounds = 3.5f;
    // Reset hit count
    hitCount = 0;
  }
}
