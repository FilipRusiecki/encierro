using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    public void SetScore(int t_increment)
    {
        scoreText.text = "Score: " + score.ToString();
        score += t_increment;
    }
    public int GetScore()
    {
        return score;
    }
}
