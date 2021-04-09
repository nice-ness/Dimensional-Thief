using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    private int score;

    private void Awake()
    {
        score = 0;
    }

    public virtual void updateScore(int scoreToPutIn)
    {
        score += scoreToPutIn;
        Debug.Log("Score: " + score);
        updateUI();
    }

    public void updateUI()
    {
        scoreUI.text = "Score: " + score;
    }
}
