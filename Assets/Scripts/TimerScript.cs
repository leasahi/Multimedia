using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
     float TimeLeft = 1080;
    public bool TimerOn = false;
    public LogicScript logic;
    public GameObject Timer;

    public Text TimerTxt;    



    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("time: " + TimeLeft);
        //if (logic.gameOverScreen.activeSelf)
        //{Timer.SetActive(false);}

        if (TimerOn && !logic.startGameScreen.activeSelf)
        {
            if (TimeLeft > 0 && TimeLeft < 1200)
            {
                TimeLeft += Time.deltaTime*0.15f;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is up");
                TimeLeft = 0;
                TimerOn = false;
                logic.gameOver();
            }
        }
        
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

}
