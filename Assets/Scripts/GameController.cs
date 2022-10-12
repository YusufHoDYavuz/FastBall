using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public RectTransform ballTransform, ballDarkTransform;
    public GameObject ball, ballDark;
    public GameObject startButton, pauseButton, goButton;
    public Text scoreText;
    public Text highScoreText;
    public Text lastScoreText;
    int score;
    int lastScore;
    public float ballSpeed;

    private void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        lastScoreText.text = PlayerPrefs.GetInt("LastScore").ToString() + " :Last Score";
    }

    private void Update()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void Game()
    {
        ballTransform.transform.localPosition = new Vector3(0, 650, 0);
        float grapeDarkRandomPos = Random.Range(-700, 400);
        ballDarkTransform.transform.localPosition = new Vector3(0, grapeDarkRandomPos, 0);
        ballTransform.transform.DOLocalMove(new Vector3(0, -750, 0), ballSpeed).OnComplete(()=> {
            ballSpeed = 10;
            score = 0;
            Game();
        });
        startButton.SetActive(false);
        pauseButton.SetActive(true);
        scoreText.text = score.ToString();
    }

    public void Pressed()
    {
        ballTransform.transform.DOKill();
        float distance = Vector2.Distance(ball.transform.position, ballDark.transform.position);

        if (distance > 30)
        {
            score = 0;
            Game();
        }

        if (distance <= 30)
        {
            score++;
            lastScore = score;
            PlayerPrefs.SetInt("LastScore", lastScore);
            Game();
        }

        if (score % 10 == 0)
        {
            ballSpeed--;
        }

        if (score == 0)
        {
            ballSpeed = 10;
        }
        scoreText.text = score.ToString();

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        goButton.SetActive(true);
    }

    public void GoGame()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        goButton.SetActive(false);
    }
}
