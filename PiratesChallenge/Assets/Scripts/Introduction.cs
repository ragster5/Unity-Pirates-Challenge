using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Introduction : MonoBehaviour
{
    public Button play;
    public TextMeshProUGUI countDownTxt;
    int countDown = 3;
    // Start is called before the first frame update
    void Start()
    {
        countDownTxt.text = countDown.ToString();
        InvokeRepeating("Count", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Count()
    {
        countDown--;
        countDownTxt.text = countDown.ToString();
        SoundEffectsController.PlaySound(SoundsList.CountDown);
        if(countDown == 0)
        {
            SoundEffectsController.PlaySound(SoundsList.Ready);
            CancelInvoke();
            play.interactable = true;
        }
    }
    public void PlayGame()
    {
        GameController.gamePhase = GamePhases.Game;
    }
}
