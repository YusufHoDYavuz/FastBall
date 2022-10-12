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
    public Text counterText;
    float counter;
    public float ballSpeed;

    public void Game()
    {
        ballTransform.transform.localPosition = new Vector3(0, 650, 0);
        float grapeDarkRandomPos = Random.Range(-700, 400);
        ballDarkTransform.transform.localPosition = new Vector3(0, grapeDarkRandomPos, 0);
        ballTransform.transform.DOLocalMove(new Vector3(0, -750, 0), ballSpeed).OnComplete(()=> {
            ballSpeed = 10;
            counter = 0;
            Game();
        });
        startButton.SetActive(false);
        pauseButton.SetActive(true);
        counterText.text = counter.ToString();
    }

    public void Pressed()
    {
        ballTransform.transform.DOKill();
        float distance = Vector2.Distance(ball.transform.position, ballDark.transform.position);

        if (distance > 30)
        {
            counter = 0;
            Game();
        }

        if (distance <= 30)
        {
            counter++;
            Game();
        }

        if (counter % 10 == 0)
        {
            ballSpeed--;
            print(counter);
        }

        if (counter == 0)
        {
            ballSpeed = 10;
        }
        counterText.text = counter.ToString();

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
