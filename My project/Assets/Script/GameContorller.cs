using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameContorller : MonoBehaviour
{
    public float GameTime;
    public bool TimerOn = false;
    public TMP_Text CountDownTimer;
    public TMP_Text ObjectiveCountDown;
    public PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        //TimerOn = true;

    }

    void Update()
    {
        
            if (GameTime > 0)
            {
                GameTime -= Time.deltaTime;
                DisplayTime(GameTime);
                DisplayObjective();
            }
            else
            {
                //TimerOn = false;
                GameOver();
            }

       

       
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        //    float milliSeconds = (timeToDisplay % 1) * 1000;
        //    CountDownTimer.text = string.Format("{1:00}:{2:000}", seconds, milliSeconds);
        //}
        CountDownTimer.text = "Time:" + GameTime;
    }

    void DisplayObjective()
    {

        if (playerScript.ObjectiveNumber < 0)
        {
            playerScript.ObjectiveNumber = 0;
        }
        ObjectiveCountDown.text = "Objective:" + playerScript.ObjectiveNumber;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("GameOver");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("GameClear");
        Debug.Log("GameClear");
    }

}
