using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

  [SerializeField] GameObject explosionParticle;
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
    // If the ball collides with the out of bounds check, add a point to the other player
    if (collision.gameObject.name == "OutBoundsCheckA")
    {
      gameManager.scoreB();
      Destroy(gameObject);

      PlayExplosionEffect();
      return;
    }
    else if (collision.gameObject.name == "OutBoundsCheckB")
    {
      gameManager.scoreA();
      Destroy(gameObject);

      PlayExplosionEffect();
      return;
    }
  }

  //Play explosion particle
  void PlayExplosionEffect()
  {
    GameObject particleInstance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
    particleInstance.GetComponent<ParticleSystem>().Play();
    Destroy(particleInstance, 1f);
  }

}
