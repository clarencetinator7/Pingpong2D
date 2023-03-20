using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

  [SerializeField] GameObject explosionParticle;
  Vector2 direction = Vector2.one.normalized;
  GameManager gameManager;
  SoundController soundManager;

  // Start is called before the first frame update
  void Start()
  {
    gameManager = FindObjectOfType<GameManager>();
    soundManager = FindObjectOfType<SoundController>();
  }

  // Called when the ball collides with something
  private void OnCollisionEnter2D(Collision2D collision)
  {
    // If the ball collides with the out of bounds check, add a point to the other player
    if (collision.gameObject.name == "OutBoundsCheckA")
    {
      gameManager.scoreB();
      Destroy(gameObject);
      // Camera shake
      Camera.main.GetComponent<CameraShake>().Shake(0.5f);
      PlayExplosionEffect();
      return;
    }
    else if (collision.gameObject.name == "OutBoundsCheckB")
    {
      gameManager.scoreA();
      Destroy(gameObject);
      // Camera shake
      Camera.main.GetComponent<CameraShake>().Shake(0.5f);
      PlayExplosionEffect();
      return;
    }

    // If the ball collides with a paddle, play the ball hit sound effect
    soundManager.PlayBallHit();

  }

  //Play explosion particle
  void PlayExplosionEffect()
  {
    GameObject particleInstance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
    particleInstance.GetComponent<ParticleSystem>().Play();
    Destroy(particleInstance, 1f);
  }

}
