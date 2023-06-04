using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    private TextMeshProUGUI timerText;
    private int timer = 60;
    public GameObject player;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + 0;
        highScoreText.text = "High Score: " + highScore;
        lifeText.text = "Life: " + player.GetComponent<PlayerMovement2>().life.ToString();
        timerText.text = timer.ToString();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(player.GetComponent<PlayerMovement2>().score);
        UpdateLife(player.GetComponent<PlayerMovement2>().life);
        //update timer every second
        time += Time.deltaTime;
        while (time >= 1.0f)
        {
            UpdateTimer();
            time -= 1.0f;
        }
    }

    public void UpdateScore(int playerScore)
    {
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
        lifeText.text = "Life: " + playerLife.ToString();
    }

    public void UpdateTimer()
    {
        timer -= 1;
        timerText.text = timer.ToString();
        if(timer == 0)
            SceneManager.LoadScene(3);
    }
}
