using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

  public AudioSource audioSource;

  // Sound Effect Clips
  public AudioClip ballHit;
  public AudioClip ballExplode;

  void Start()
  {
    // Get the audio source component
    audioSource = GetComponent<AudioSource>();
  }

  // Play the ball hit sound effect
  public void PlayBallHit()
  {
    audioSource.PlayOneShot(ballHit);
  }

  public void PlayBallExplode()
  {
    audioSource.PlayOneShot(ballExplode);
  }

}
