using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public RectTransform grape, grapeDark;
    public GameObject grape2, grapeDark2;
    public Text counter;
    float myCounter;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Game();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Pressed();
        }
    }

    void Game()
    {
        grape.transform.localPosition = new Vector3(0, 750, 0);
        float grapeDarkRandomPos = Random.Range(-700, 400);
        grapeDark.transform.localPosition = new Vector3(0, grapeDarkRandomPos, 0);
        grape.transform.DOLocalMove(new Vector3(0, -750, 0), 8).OnComplete(()=> {
            //Game();
        });
    }

    void Pressed()
    {
        grape.transform.DOKill();
        float distance = Vector2.Distance(grape2.transform.position, grapeDark2.transform.position);
        //float distance = grapeDark.transform.localPosition.y - grape.transform.localPosition.y;
        if (distance <= 30)
        {
            myCounter++;
            counter.text = myCounter.ToString();
            Game();
        }
    }

}
