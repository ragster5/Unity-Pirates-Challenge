using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + PlayerPrefs.GetInt("Score");
    }
    public void SceneLoader(string name)
    {
        SceneManager.LoadScene(name);
    }
}
