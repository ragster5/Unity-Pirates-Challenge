using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerTxt;
    GameController gc;
    float secondsBase;
    int seconds, minutes;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        seconds = 00;
        secondsBase = 00;
        if (PlayerPrefs.HasKey("MatchDuration"))
        {
            minutes = PlayerPrefs.GetInt("MatchDuration");
        } else
        {
            minutes = 1;
        }
        timerTxt = GetComponent<TextMeshProUGUI>();
    }



    // Update is called once per frame
    void Update()
    {
        if (GameController.gamePhase.Equals(GamePhases.Game))
        {
            secondsBase -= Time.deltaTime;
            seconds = (int)secondsBase;
            if (seconds == 00)
            {
                minutes--;
                secondsBase = 60;
                seconds = 60;
            }
            if (seconds >= 10)
            {
                timerTxt.text = "0" + minutes + ":" + seconds;
            }
            else
            {
                timerTxt.text = "0" + minutes + ":0" + seconds;
                if (minutes == 0 && seconds == 0)
                {
                    gc.EndGame();
                }
            }
        }
    }
}
