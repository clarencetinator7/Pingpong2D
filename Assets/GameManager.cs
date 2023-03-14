using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

  float playerAScore = 0;
  float playerBScore = 0;
  //   public static char lastHit = ' ';

  [SerializeField] TextMeshProUGUI playerAScoreText;
  [SerializeField] TextMeshProUGUI playerBScoreText;

  [SerializeField] GameObject ball;

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
    Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
  }


}
