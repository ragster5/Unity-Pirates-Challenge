using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Title : MonoBehaviour
{
    public TextMeshProUGUI matchDurationTxt, spawnTimeTxt;
    int matchDuration = 2, spawnTime = 5;
    private void Start()
    {
        PlayerPrefs.SetInt("MatchDuration", matchDuration);
        PlayerPrefs.SetInt("SpawnTime", spawnTime);
    }
    public void PlayBtn()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void ModifyMatchDuration(int value)
    {
        if(value < 0 && matchDuration == 1 || value > 0 && matchDuration == 3)
        {
            return;
        }
        matchDuration += value;
        PlayerPrefs.SetInt("MatchDuration", matchDuration);
        matchDurationTxt.text = matchDuration.ToString();
    }
    public void ModifySpawnDuration(int value)
    {
        if(value <0 && spawnTime == 1)
        {
            return;
        }
        spawnTime += value;
        PlayerPrefs.SetInt("SpawnTime", spawnTime);
        spawnTimeTxt.text = spawnTime.ToString();
    }

}
