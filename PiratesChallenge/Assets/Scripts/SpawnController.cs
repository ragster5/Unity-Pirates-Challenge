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
        timer = PlayerPrefs.GetFloat("SpawnTime");
        spawns = GetComponentsInChildren<Spawn>();
        InvokeRepeating("Spawn", 0, timer);
    }
    void Spawn()
    {
        spawns[Random.Range(0, spawns.Length)].SpawnRandomEnemy(enemy[Random.Range(0, enemy.Length)]);
    }
}
