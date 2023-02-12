using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemy;
    Spawn[] spawns = new Spawn[4];
    // Start is called before the first frame update
    void Start()
    {
        spawns = GetComponentsInChildren<Spawn>();
        InvokeRepeating("Spawn", 0, 2);
    }
    void Spawn()
    {
        spawns[Random.Range(0, spawns.Length)].SpawnRandomEnemy(enemy[Random.Range(0, enemy.Length)]);
    }
}
