using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script shakes the camera when called.
public class CameraShake : MonoBehaviour
{
  // The duration of the camera shake.
  public float duration = 1f;

  // The animation curve that controls the camera shake.
  public AnimationCurve curve;

  // Whether to start shaking the camera.
  public bool start = false;

  // Update is called once per frame.
  void Update()
  {
    // If start is true, shake the camera.
    if (start)
    {
      // Set start to false to prevent multiple shakes at once.
      start = false;
      StartCoroutine(Shaking());
    }
  }

  // Shake the camera for the given amount of time.
  public void Shake(float sec)
  {
    // Set the duration of the camera shake.
    duration = sec;

    // Set start to true to initiate the camera shake.
    start = true;
  }

  // Coroutine that shakes the camera.
  IEnumerator Shaking()
  {
    // The camera's original position.
    Vector3 originalPos = new Vector3(0, 0, -10);

    // The elapsed time since the camera started shaking.
    float elapsedTime = 0.0f;

    // Shake the camera for the duration of the camera shake.
    while (elapsedTime < duration)
    {
      elapsedTime += Time.deltaTime;

      // Evaluate the animation curve to get the current shake strength.
      float strength = curve.Evaluate(elapsedTime / duration);
      // Shake the camera by a random amount based on the shake strength.
      transform.position = originalPos + Random.insideUnitSphere * strength;
      // Wait for the next frame.
      yield return null;
    }
    // Reset the camera's position to its original position.
    transform.position = originalPos;
  }
}

