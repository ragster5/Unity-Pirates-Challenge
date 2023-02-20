using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemy;
    Spawn[] spawns = new Spawn[4];
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SpawnTime"))
        {
            timer = PlayerPrefs.GetInt("SpawnTime");
        } else
        {
            timer = 3;
        }
        spawns = GetComponentsInChildren<Spawn>();
        InvokeRepeating("Spawn", 1, timer);
    }
    void Spawn()
    {
        spawns[Random.Range(0, spawns.Length)].SpawnRandomEnemy(enemy[Random.Range(0, enemy.Length)]);
        if (!GameController.gamePhase.Equals(GamePhases.Game))
        {
            CancelInvoke();
        }
    }
}
