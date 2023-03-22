using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

  // Reference to the explosion particle effect
  [SerializeField] GameObject explosionParticle;
  [SerializeField] GameObject ballHitParticle;

  // Reference to the game manager and sound manager 
  GameManager gameManager;
  SoundController soundManager;

  // Start is called before the first frame update
  void Start()
  {
    // Initialize the game manager and sound manager object.
    gameManager = FindObjectOfType<GameManager>();
    soundManager = FindObjectOfType<SoundController>();
  }

  // Called when the ball collides with something
  private void OnCollisionEnter2D(Collision2D collision)
  {
    // If the ball collides with the out of bounds check, add a point to the other player
    if (collision.gameObject.name == "OutBoundsCheckA")
    {
      // Add a point to player B
      gameManager.scoreB();
      // Destroy the ball
      Destroy(gameObject);
      // Camera shake
      Camera.main.GetComponent<CameraShake>().Shake(0.5f);
      // Play explosion particle
      PlayExplosionEffect();
      // Play explosion sound effect
      soundManager.PlayBallExplode();
      return;
    }
    else if (collision.gameObject.name == "OutBoundsCheckB")
    {
      gameManager.scoreA();
      Destroy(gameObject);
      Camera.main.GetComponent<CameraShake>().Shake(0.5f);
      PlayExplosionEffect();
      soundManager.PlayBallExplode();
      return;
    }
    else
    {
      // Play ball hit particle
      PlayBallHitEffect();
    }

    // If the ball collides with a paddle, play the ball hit sound effect
    soundManager.PlayBallHit();

  }

  //Play explosion particle
  void PlayExplosionEffect()
  {
    // Instantiate the explosion particle effect
    GameObject particleInstance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
    // Play the particle effect
    particleInstance.GetComponent<ParticleSystem>().Play();
    // Destroy the particle effect after 1 second
    Destroy(particleInstance, 1f);
  }

  void PlayBallHitEffect()
  {
    // Instantiate the explosion particle effect
    GameObject particleInstance = Instantiate(ballHitParticle, transform.position, Quaternion.identity);
    // Play the particle effect
    particleInstance.GetComponent<ParticleSystem>().Play();
    // Destroy the particle effect after 1 second
    Destroy(particleInstance, 1f);
  }



}
