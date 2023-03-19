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

  // TODO: Game Reset
  public void respawnBall()
  {
    ballInstance = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
  }

  public void startGame()
  {

  }

  public void launchBall()
  {

    // Random 1 or -1
    float randomX = Random.Range(0, 2) * 2 - 1;
    print(randomX);
    float randomY = Random.Range(-1f, 1f);

    Vector2 direction = new Vector2(randomX, randomY).normalized;

    ballInstance.GetComponent<Rigidbody2D>().velocity = direction * 10f;

  }


}
