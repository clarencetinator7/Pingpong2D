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

  public void scoreA()
  {
    playerAScore++;
    // playerAScoreText.text = playerAScore.ToString();
    print("Player A score: " + playerAScore + " Player B score: " + playerBScore);
  }

  public void scoreB()
  {
    playerBScore++;
    // playerBScoreText.text = playerBScore.ToString();
    print("Player A score: " + playerAScore + " Player B score: " + playerBScore);
  }


}
