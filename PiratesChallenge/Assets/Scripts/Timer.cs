using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerTxt;
    float secondsBase;
    int seconds, minutes;
    // Start is called before the first frame update
    void Start()
    {
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
        secondsBase -= Time.deltaTime;
        seconds = (int)secondsBase;
        if (seconds == 00)
        {
            minutes--;
            secondsBase = 59;
            seconds = 59;
        }
        if (seconds >= 10)
        {
            timerTxt.text = "0" + minutes + ":" + seconds;
        }
        else
        {
            timerTxt.text = "0" + minutes + ":0" + seconds;
            if(minutes == 0 && seconds == 0)
            {
                //Jogo Finalizado
            }
        }
    }
}
