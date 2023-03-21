using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

  // Score of player A and B
  float playerAScore = 0;
  float playerBScore = 0;
  // Ball speed
  [SerializeField] float ballSpeed = 20f;

  // UI Element that displays the score for player A and B
  [SerializeField] TextMeshProUGUI playerAScoreText;
  [SerializeField] TextMeshProUGUI playerBScoreText;

  // Game Object references for ball
  [SerializeField] GameObject ball;
  // Game Object references for paddles
  [SerializeField] GameObject paddleA;
  [SerializeField] GameObject paddleB;

  // Reference to the ball instance
  GameObject ballInstance;

  public void Start()
  {
    // On Start, respawn the ball at the center of the screen
    respawnBall();
  }

  public void Update()
  {
    // If player presses space, it launches the ball
    if (Input.GetKeyDown(KeyCode.Space))
    {
      launchBall();
    }
  }

  // Adds one to player A's score and respawn the ball.
  public void scoreA()
  {
    playerAScore++;
    playerAScoreText.text = playerAScore.ToString();
    respawnBall();
  }

  // Adds one to player B's score and respawn the ball.
  public void scoreB()
  {
    playerBScore++;
    playerBScoreText.text = playerBScore.ToString();
    respawnBall();
  }

  // Respawn Ball at the center of the screen
  public void respawnBall()
  {
    // Instantiate the ball at the center of the screen
    // Store it in a variable so we can access it later
    ballInstance = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);

    // Resets the paddle size by calling the Reset() function in the PlayerA and PlayerB scripts
    paddleA.GetComponent<PlayerA>().Reset();
    paddleB.GetComponent<PlayerB>().Reset();
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

    // Set the velocity of the ball to the direction * ballSpeed
    ballInstance.GetComponent<Rigidbody2D>().velocity = direction * ballSpeed;

  }


}
