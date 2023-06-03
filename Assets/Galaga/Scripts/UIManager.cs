using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int highScore;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    [SerializeField]
    private TextMeshProUGUI lifeText;

    //UIManager uiManager = new UIManager();

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + 0;
        highScoreText.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int playerScore)
    {
        //uiManager.scoreText.text = "Score: " + playerScore.ToString();
        scoreText.text = "Score: " + playerScore.ToString();
        UpdateHighScore(playerScore);
    }

    // if current score is higher than high score, update high score
    public void UpdateHighScore(int playerScore)
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    public void UpdateLife(int playerLife)
    {

    }
}
