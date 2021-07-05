using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int scoreOneLine = 100;
    int scoreTwoLine = 400;
    int scoreThreeLine = 1000;
    int scoreFourLine = 3000;

    public int numberOfRowsThisTurn = 0;

    public Text scoreText;
    public int currentScore = 0;

    private void Update()
    {
        UpdateScore();
    }
    void UpdateScore()
    {
        if (numberOfRowsThisTurn > 0)
        {
            if (numberOfRowsThisTurn == 1)
            {
                currentScore += scoreOneLine;
                scoreText.text = "Score: "+currentScore.ToString();
            }
            else if (numberOfRowsThisTurn == 2)
            {
                currentScore += scoreTwoLine;
                scoreText.text = "Score: " + currentScore.ToString();
            }
            else if (numberOfRowsThisTurn == 3)
            {
                currentScore += scoreThreeLine;
                scoreText.text = "Score: " + currentScore.ToString();
            }
            else if (numberOfRowsThisTurn == 4)
            {
                currentScore += scoreFourLine;
                scoreText.text = "Score: " + currentScore.ToString();
            }
            numberOfRowsThisTurn = 0;
        }
    }
}
