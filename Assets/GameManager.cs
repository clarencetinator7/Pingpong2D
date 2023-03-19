using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

  float playerAScore = 0;
  float playerBScore = 0;

  [SerializeField] TextMeshProUGUI playerAScoreText;
  [SerializeField] TextMeshProUGUI playerBScoreText;

  [SerializeField] GameObject ball;
  GameObject ballInstance;

  public void Start()
  {
    respawnBall();
  }

  public void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      launchBall();
    }
  }

  public void scoreA()
  {
    playerAScore++;
    playerAScoreText.text = playerAScore.ToString();
    respawnBall();
  }

  public void scoreB()
  {
    playerBScore++;
    playerBScoreText.text = playerBScore.ToString();
    respawnBall();
  }

  // Respawn Ball at the center of the screen
  public void respawnBall()
  {
    ballInstance = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
  }

  // Launch the ball in a random direction
  public void launchBall()
  {

    // Random 1 or -1 (Left or Right)
    float randomX = Random.Range(0, 2) * 2 - 1;
    // For Y, to make sure it's not too vertical
    float randomY = Random.Range(-1f, 1f);

    // Store the direction in a Vector2
    // Since we are only concern with the direction, we normalize it
    Vector2 direction = new Vector2(randomX, randomY).normalized;

    ballInstance.GetComponent<Rigidbody2D>().velocity = direction * 10f;

  }


}
