using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
  public float duration = 1f;
  public AnimationCurve curve;
  public bool start = false;

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (start)
    {
      start = false;
      StartCoroutine(Shaking());
    }
  }

  IEnumerator Shaking()
  {
    Vector3 originalPos = transform.position;
    float elapsedTime = 0.0f;

    while (elapsedTime < duration)
    {
      elapsedTime += Time.deltaTime;
      float strength = curve.Evaluate(elapsedTime / duration);
      transform.position = originalPos + Random.insideUnitSphere * strength;
      yield return null;
    }

    transform.position = originalPos;

  }

}
